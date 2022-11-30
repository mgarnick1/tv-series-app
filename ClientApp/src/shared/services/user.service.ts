import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiServiceService } from './api-service.service';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private apiService: ApiServiceService) {}

  getUser(userId: string): Observable<any>{
    let params = new HttpParams();
    params = params.append('userId', userId);
    return this.apiService.getItem('api/authorize/user', params)
  }
}
