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
    this.selectTvSeries.emit(tvSeries);
  }

  networkLogo(network: string): string {
    const networkLowercase = network.toLowerCase();
    let logos: Record<string, string> = {
      'sci-fi channel':
        'https://deadline.com/wp-content/uploads/2017/05/syfy-new-black-logo-featured.jpg',
      hbo: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTqY-JqORD0VQGBbbOcVGXQKMHbqUBcWXUHZQ&usqp=CAU',
      netflix:
        'https://images.ctfassets.net/4cd45et68cgf/Rx83JoRDMkYNlMC9MKzcB/2b14d5a59fc3937afd3f03191e19502d/Netflix-Symbol.png?w=684&h=456',
      bravo: 'https://upload.wikimedia.org/wikipedia/commons/3/3e/Bravo_TV.svg',
    };
    return (
      logos[networkLowercase] ||
      'https://cdn.vectorstock.com/i/preview-1x/48/06/image-preview-icon-picture-placeholder-vector-31284806.jpg'
    );
  }
}
