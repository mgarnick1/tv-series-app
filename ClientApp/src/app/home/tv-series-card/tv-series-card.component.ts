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
  starCount: number = 5;
  constructor() {}

  ngOnInit(): void {}

  edit(tvSeries: TVSeries) {
    this.selectTvSeries.emit(tvSeries)
  }
}
