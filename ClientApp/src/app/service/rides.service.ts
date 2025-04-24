import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { ApiService } from './api.service';
import { environment } from '../environment/environment';



@Injectable({
  providedIn: 'root'
})
export class ridesService {
  private endpoint = 'Booking'; 
private apiURL = environment.baseUrl
  constructor(private Http: HttpClient, private apiService: ApiService, ) {

   }
   getRides(): Observable<any[]> {
    return this.apiService.get(`Booking/GetAll`).pipe(
    map((response: any) => response.data || response)
   );
  }
  UpdateStatus(Id: any, StatusId: number): Observable<any> {
    return this.apiService.put(`${this.endpoint}/${Id}/Status?bookingStatus=${StatusId}`,StatusId); 
  }
  getById(Id: any): Observable<any> {
    return this.apiService.get(`Booking/GetBy/${Id}`);
  }
}