import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-tv-rating-star',
  templateUrl: './tv-rating-star.component.html',
  styleUrls: ['./tv-rating-star.component.css'],
})
export class TvRatingStarComponent implements OnInit {
  @Input() rating: number;
  @Input() starCount: number = 5;
  @Input() color: string = 'accent';
  // @Output() ratingUpdated = new EventEmitter<number>();
  ratingArr: number[] = [];

  constructor() {}

  ngOnInit(): void {
    for (let index = 0; index < this.starCount; index++) {
      this.ratingArr.push(index);
    }
  }

  showIcon(index: number) {
    if (this.rating >= index + 1) {
      return 'star';
    } else {
      return 'star_border';
    }
  }
}
