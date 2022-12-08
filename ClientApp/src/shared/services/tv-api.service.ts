import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TVSeries } from 'src/_interfaces/tv-series/tv-series.model';
import { ApiServiceService } from './api-service.service';

@Injectable({
  providedIn: 'root'
})
export class TvApiService {
  url = '/api/tv-series'

  constructor(private apiService: ApiServiceService) { }

  createTVSeries(tvSeries: TVSeries) {
    let params = new HttpParams();
    return this.apiService.postItem(`${this.url}/add`, tvSeries, params)
  }

  editTVSeries(tvSeries: TVSeries) {
    let params = new HttpParams();
    return this.apiService.editItem(`${this.url}/edit`, tvSeries, params)
  }
}
