import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LocalService } from './local-service.service';
import { TokenExpirationService } from './token-expiration.service';

@Injectable({
  providedIn: 'root',
})
export class ApiServiceService {
  httpOptions = new HttpHeaders({
    'Content-Type': 'application/json',
  });
  baseUrl: string = 'https://localhost:7091';

  constructor(
    private http: HttpClient,
    private storage: LocalService,
    private tokenExpiration: TokenExpirationService
  ) {}

  private validateToken(): HttpHeaders | null {
    let token = this.storage.getData('token');
    if (token) {
      this.tokenExpiration.revokeExpiredToken(token);
      const tokenExists = this.storage.getData('token');
      if (tokenExists) {
        this.httpOptions = this.httpOptions.set(
          'Authorization',
          `Bearer ${tokenExists}`
        );
        return this.httpOptions;
      }
      return null;
    }
    return null;
  }

  getItem(url: string, options?: any) {
    let headers = this.validateToken();
    if (headers) {
      return this.http
        .get(`${this.baseUrl}/${url}`, { params: options, headers: headers })
        .pipe(catchError(this.handleError));
    }
    throw new Error('Invalid Token');
  }

  postItem(url: string, body?: any, options?: any) {
    let headers = this.validateToken();
    if (headers) {
      return this.http
        .post(`${this.baseUrl}${url}`, body, {
          params: options,
          headers: headers,
        })
        .pipe(catchError(this.handleError));
    }
    throw new Error('Invalid Token');
  }

  editItem(url: string, body?: any, options?: any) {
    let headers = this.validateToken();
    if (headers) {
      return this.http
        .put(`${this.baseUrl}${url}`, body, {
          params: options,
          headers: headers,
        })
        .pipe(catchError(this.handleError));
    }
    throw new Error('Invalid Token');
  }

  deleteItem(url: string, options?: any) {
    let headers = this.validateToken();
    if (headers) {
      return this.http
        .delete(`${this.baseUrl}${url}`, { params: options, headers: headers })
        .pipe(catchError(this.handleError));
    }
    throw new Error('Invalid Token');
  }

  private handleError(error: HttpErrorResponse) {
    debugger;
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `,
        error.error
      );
    }
    // Return an observable with a user-facing error message.
    return throwError(
      () => new Error('Something bad happened; please try again later.')
    );
  }
}
