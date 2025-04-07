import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { environment } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class AddVehicleService {
  private endpoint = 'DriverVehicle';
private apiURL = environment.baseUrl
  constructor(private Http: HttpClient, private apiService: ApiService, ) { }


  addVehicle(vehicleData: any): Observable<any> {
    return this.apiService.post(`DriverVehicle/Add`, vehicleData);
  }
  deletevehicle(Id: string, vehicleData: any): Observable<any>{
    return this.apiService.delete(`DriverVehicle/Delete/${Id}`);
  }
}


