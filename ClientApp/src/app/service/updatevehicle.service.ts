import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { environment } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class UpdateVehicleService {
  private endpoint = 'DriverVehicle';
private apiURL = environment.baseUrl
  constructor(private Http: HttpClient, private apiService: ApiService, ) { 
    
  }
  updatevehicle(Id: any, formData: any): Observable<any>{
    return this.apiService.put(`DriverVehicle/Update/${Id}`, formData);
  }
  getById(Id: any): Observable<any> {
    return this.apiService.get(`DriverVehicle/GetBy/${Id}`);
  }
}



