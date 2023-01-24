import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TVSeries } from 'src/_interfaces/tv-series/tv-series.model';
import { ApiServiceService } from './api-service.service';

@Injectable({
  providedIn: 'root',
})
export class TvApiService {
  url = '/api/tv-series';

  constructor(private apiService: ApiServiceService) {}

  createTVSeries(tvSeries: TVSeries) {
    let params = new HttpParams();
    return this.apiService.postItem(`${this.url}/add`, tvSeries, params);
  }

  editTVSeries(tvSeries: TVSeries) {
    let params = new HttpParams();
    return this.apiService.editItem(`${this.url}/edit`, tvSeries, params);
  }

  uploadImageGetUrl(formData: FormData, userId: string) {
    let params = new HttpParams();
    params = params.append('userId', userId);
    return this.apiService.uploadFile(
      `${this.url}/upload/${userId}`,
      formData,
      params
    );
  }

  getRecommendations(page: number, userId: string) {
    let params = new HttpParams();
    params = params.set("page", page)
    params = params.set("userId", userId)
    return this.apiService.getItem(`api/tv-series/recommendations`, params )
  }
}
