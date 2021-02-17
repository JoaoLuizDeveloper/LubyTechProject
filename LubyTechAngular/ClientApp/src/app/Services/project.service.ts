import { Injectable, Component, Pipe, Directive } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { IProject } from '../Models/project.interface';
import { map, catchError, retry } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { throwError } from 'rxjs/internal/observable/throwError';
import { error } from '@angular/compiler/src/util';

@Injectable()

export class ProjectService {
  project: IProject = <IProject>{};
  url = 'https://localhost:44387/api/v1/projects/';
  url2 = 'https://localhost:44387/api/v2/projects/';
  token = "";
  // injetando o HttpClient
  constructor(private http: HttpClient) {
    
  }

  //Header
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + this.token })
  }

  //Getting Token
  async getToken(){
    await fetch("https://localhost:44387/api/v2/developers/GetToken", { method: 'get' }).then(response => 
      response.text().then(function (text) {
        this.token = text;
      })
    );
  }

  // Get all the projects
  getProjects(): Observable<IProject[]> {
    var retorno = this.http.get<IProject[]>(this.url)
      .pipe(
        retry(1),
        catchError(this.handleError));
    return retorno;
  }

  // Get one Project By Id
  getProjectById(id: Int32Array): Observable<IProject>{
    this.getToken();
    
    return this.http.get<IProject>(this.url + id, this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError));
  }
    
  // Create one Project
  saveProject(project: IProject): Observable<IProject> { 
    return this.http.post<IProject>(this.url, JSON.stringify(project))
      .pipe(
        retry(1),
        catchError(this.handleError)
      );
  }

  // Adding Dev To Project
  addDevToProject(developerId: Int32Array, projectId: Int32Array) {
    var resposta = this.http.get(this.url2 + developerId + projectId)
      .pipe(
        retry(1),
        catchError(this.handleError)
      );
    return resposta;
  }

  // Update one Project
  updateProject(project: IProject): Observable<IProject> {
    return this.http.patch<IProject>(this.url, JSON.stringify(project))
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  // delete one Project
  deleteProject(projectId: Int32Array) {
    return this.http.delete<IProject>(this.url + projectId)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  // Figure out some mistakes
  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Client Side Mistake
      errorMessage = error.error.message;
    } else {
      // Server Side Mistake
      errorMessage = `Error code: ${error.status}, ` + `message: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };
}
