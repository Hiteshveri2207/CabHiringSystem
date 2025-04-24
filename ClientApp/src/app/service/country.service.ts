import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { environment } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  private endpoint = 'Country'; 
private apiURL = environment.baseUrl
  constructor(private Http: HttpClient, private apiService: ApiService) { }

  getCountry(): Observable<any[]> {
    return this.apiService.get(`Country/GetAll`);
}
}