import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { environment } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  private endpoint = 'Auth'; 
private apiURL = environment.baseUrl
  constructor(private Http: HttpClient, private apiService: ApiService) { }

  getRoles(): Observable<any[]> {
    return this.apiService.get(`role/GetAllRoles`);
}
}