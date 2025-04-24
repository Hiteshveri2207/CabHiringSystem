import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { environment } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class StateService {
  getCountry() {
    throw new Error('Method not implemented.');
  }
  private endpoint = 'State'; 
private apiURL = environment.baseUrl
  constructor(private Http: HttpClient, private apiService: ApiService) { }

  getStates(): Observable<any[]> {
    return this.apiService.get(`State/GetAll`);
}
}