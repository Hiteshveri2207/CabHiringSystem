import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { ApiService } from './api.service';
import { environment } from '../environment/environment';


@Injectable({
  providedIn: 'root'
})
export class bookingstatusService {
  private endpoint = 'BookingStatus'; 
private apiURL = environment.baseUrl
  constructor(private Http: HttpClient, private apiService: ApiService, ) {

   }
   
  GetStatuses(): Observable<any[]>
  {
    return this.apiService.get(`${this.endpoint}/statuses`);
  }
}