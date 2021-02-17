import { Injectable, Component, Pipe, Directive } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse  } from '@angular/common/http';
import { IDeveloper } from '../Models/developer.interface';
import { IHourByDeveloper } from '../Models/hourByDeveloper.interface';
import { IProject } from '../Models/project.interface';
import { map, catchError, retry } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { throwError } from 'rxjs/internal/observable/throwError';

@Injectable()

export class DeveloperService {
  url = 'https://localhost:44387/api/v1/developers/';
  url2 = 'https://localhost:44387/api/v2/developers/';
  // injetando o HttpClient
  constructor(private http: HttpClient) {
  }
  // Headers
  httpOptions = { 
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  // Get all developers
  getDevelopers(): Observable<IDeveloper[]> {
    return this.http.get<IDeveloper[]>(this.url, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError));
  }

  // Get ranking of developers
  getRanking(): Observable<IHourByDeveloper[]> {
    return this.http.get<IHourByDeveloper[]>(this.url2, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError));
  }

  //Verify if CPF Exist
  getsearchCpf(cpf: number) {
    return this.http.get<IDeveloper[]>(this.url + 'SearchCpf/' + cpf, this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError));
  }

  // Get Token worth
  getToken() {
    return this.http.get<string>(this.url2 + 'GetToken', this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError));
  }

  // Get all the projects 
  getProjects(): Observable<IProject[]> {
    return this.http.get<IProject[]>(this.url, this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError));
  }

  // Get one Product By Id
  getDeveloperById(id: Int32Array): Observable<IDeveloper> {
    var dev = this.http.get<IDeveloper>(this.url + 'GetDeveloper/' + id, this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError));
    return dev;
  }

  // Create one Product
  saveDeveloper(developer: IDeveloper): Observable<IDeveloper> {
    return this.http.post<IDeveloper>(this.url, JSON.stringify(developer), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // Update one Product
  updateDeveloper(developer: IDeveloper): Observable<IDeveloper> {
    return this.http.patch<IDeveloper>(this.url, JSON.stringify(developer), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  // delete one Product
  deleteDeveloper(developerId: Int32Array) {
    return this.http.delete<IDeveloper>(this.url + developerId, this.httpOptions )
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
