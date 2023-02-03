import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TVSeries } from 'src/_interfaces/tv-series/tv-series.model';

@Component({
  selector: 'app-tv-series-card',
  templateUrl: './tv-series-card.component.html',
  styleUrls: ['./tv-series-card.component.css'],
})
export class TvSeriesCardComponent implements OnInit {
  @Input() tvSeries: TVSeries;
  @Output() selectTvSeries = new EventEmitter<TVSeries>();
  @Output() sendEmailRecommendation = new EventEmitter<TVSeries>();
  starCount: number = 5;
  constructor() {}

  ngOnInit(): void {}

  edit(tvSeries: TVSeries) {
    this.selectTvSeries.emit(tvSeries);
  }

  sendEmail(tvSeries: TVSeries) {
    this.sendEmailRecommendation.emit(tvSeries);
  }

  networkLogo(networkLogo: string): string {
    if (networkLogo) {
      return networkLogo;
    }
    return 'https://cdn.vectorstock.com/i/preview-1x/48/06/image-preview-icon-picture-placeholder-vector-31284806.jpg';
  }
}
