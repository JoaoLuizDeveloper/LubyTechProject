import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { catchError, retry } from 'rxjs/operators';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { Headers, Http, HttpModule } from '@angular/http';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { TokenParams } from '../ViewModel/TokenParams';

@Injectable()
export class AuthService {

  AccessToken: string = "";
  constructor(private http: Http) { }
  private TokenApi = "https://localhost:44387/api/v2/developers/GetToken";

  login(UserName: string, Password: string): Observable<TokenParams> {
    var headersForTokenAPI = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
    var data = "grant_type=password&username" + UserName + "&password" + Password;

    return this.http.post<string, string>(this.TokenApi, data, { headers: headersForTokenAPI })
      .pipe(
        retry(1),
        catchError(this.handleError));
  }

  //addHourToDeveloper(UserName: string, Password: string): Observable<TokenParams> {
  //}
}
