import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { environment } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  private endpoint = 'Auth'; // Endpoint
private apiURL = environment.baseUrl
  constructor(private Http: HttpClient, private apiService: ApiService) { }

  // register user
  register(userdata: any): Observable<any> {
    return this.apiService.post(`Auth/register`, userdata);
  }
  LogIn(userdata: any): Observable<any> {
    return this.apiService.post(`Auth/login`, userdata);
  }
 
}