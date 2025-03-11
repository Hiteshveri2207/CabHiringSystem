import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiServiceService } from './api.service';
import { environment } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  private endpoint = 'Auth'; // Endpoint
private apiURL = environment.baseUrl
  constructor(private Http: HttpClient, private apiService: ApiServiceService) { }

  // register user
  addItem(userdata: any): Observable<any> {
    return this.apiService.post(`${this.apiURL}/Auth/register`, userdata);
  }
  login(userdata: any): Observable<any> {
    return this.apiService.post(`Auth/Login`, userdata);
  }

}
