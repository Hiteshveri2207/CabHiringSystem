import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { environment } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class DriverProfileService {
  private endpoint = 'Driver';
private apiURL = environment.baseUrl
  constructor(private Http: HttpClient, private apiService: ApiService, ) { 
    
  }
 

  adddriver(driverData: any): Observable<any> {
    return this.apiService.post(`Driver/Add`, driverData);
  }
}



