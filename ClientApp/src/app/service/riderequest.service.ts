import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { environment } from '../environment/environment';
import { HttpClient } from '@angular/common/http';

export interface RideRequest {
  fromLocation: string;
  toLocation: string;
  selectTripType: string;
  departureDate: string;
  returnDate: string;
  numberOfAdults: number;
  numberOfChildren: number;
  numberOfInfants: number;
  additionalNotes: string;
}

@Injectable({
  providedIn: 'root'
})
export class riderequestService {
   
  private endpoint = 'BookRide'; 
private apiURL = environment.baseUrl
 constructor(private Http: HttpClient, private apiService: ApiService, ) { }

  

getAll(): Observable<any> {
  return this.apiService.get(`BookRide/GetAll`);
}
}
