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
export class carListService{
  private endpoint = 'DriverVehicle'; 
private apiURL = environment.baseUrl
  constructor(private Http: HttpClient, private apiService: ApiService, ) { 
    
  }


  getcar(): Observable<any> {
    return this.apiService.get(`DriverVehicle/GetAll`);
  }
}


