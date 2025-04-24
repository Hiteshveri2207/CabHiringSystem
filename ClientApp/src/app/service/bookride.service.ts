import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { environment } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class BookRideService {
  value(value: any) {
  }
    getbookride(): any {
    
  }
 private endpoint = 'BookRide'; 
private apiURL = environment.baseUrl

  constructor(private http: HttpClient,private apiService: ApiService) { }

  getRide(): Observable<any> {
    return this.http.get('BookRide/GetAll');
  }
  deleteRide(Id: string):Observable<any[]>
 {
  return this.apiService.delete(`BookRide/Delete/${Id}`);
}
 addRide(bookRideData: any): Observable<any> {
  return this.apiService.post(`BookRide/Add`, bookRideData);
  }
 
  }
  

