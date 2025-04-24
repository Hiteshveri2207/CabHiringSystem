import { Injectable } from '@angular/core';

import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiURL = environment.baseUrl
  create: Observable<any> | undefined;
  constructor(private http: HttpClient) { }

  // GET Request
  get<T>(endpoint: string): Observable<T> {
    return this.http.get<T>(`${this.apiURL}/${endpoint}`).pipe(
      catchError(this.handleError)
    );
  }

  // POST Request
  post<T>(endpoint: string, data: any, p0?: { isFormData: boolean; }): Observable<T> {
    return this.http.post<T>(`${this.apiURL}/${endpoint}`, data).pipe(
      catchError(this.handleError)
    );
  }

  // PUT Request
  put<T>(endpoint: string, data: any): Observable<T> {
    return this.http.put<T>(`${this.apiURL}/${endpoint}`, data).pipe(
      catchError(this.handleError)
    );
  }

  // DELETE Request
  delete<T>(endpoint: string): Observable<T> {
    return this.http.delete<T>(`${this.apiURL}/${endpoint}`).pipe(
      catchError(this.handleError)
    );
  }
  
  // patch<T>(url: string, body: any): Observable<T> {
  //   return this.http.patch<T>(`${this.apiURL}/${url}`, body);
  // }

  // Handle API Errors
  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'An unknown error occurred!';
    if (error.error instanceof ErrorEvent) {
      // Client-side error
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(() => new Error(errorMessage));
  }
}
