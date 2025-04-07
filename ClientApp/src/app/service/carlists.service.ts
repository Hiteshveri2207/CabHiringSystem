import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { environment } from '../environment/environment';

interface Car {
  vehicleId: number;
  brandId: string;
  seatingCapacity: number;
  vehiclenumber:number; 
  modelYear: number;
  vehiclemodel: string;
}

@Injectable({
  providedIn: 'root'
})
export class CarListsService {
  private endpoint = 'DriverVehicle'; 
private apiURL = environment.baseUrl
  constructor(private Http: HttpClient, private apiService: ApiService, ) { }


  getcars(): Observable<any> {
    return this.apiService.get(`DriverVehicle/GetAll`);
  }
 deletecars(Id: string):Observable<any[]>
 {
  return this.apiService.delete(`DriverVehicle/Delete/${Id}`);
 }
}


