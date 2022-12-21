import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NetworkLogo } from 'src/_interfaces/tv-series/network-logos.model';
import { ApiServiceService } from './api-service.service';

@Injectable({
  providedIn: 'root'
})
export class NetworkService {
  url = 'api/network-logos';
  constructor(private apiService: ApiServiceService) { }

  getNetworkLogos(userId: string): Observable<any> {
    let params = new HttpParams();
    params = params.append('userId', userId);
    return this.apiService.getItem(`${this.url}`, params)
  }

  createNetworkLogo(network: NetworkLogo) {
    let params = new HttpParams();
    return this.apiService.postItem(`${this.url}/add`, network, params);
  }

  editNetworkLogo(network: NetworkLogo) {
    let params = new HttpParams();
    return this.apiService.editItem(`${this.url}/edit`, network, params);
  }
}
