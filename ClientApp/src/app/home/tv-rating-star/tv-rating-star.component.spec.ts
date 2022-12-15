import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TvRatingStarComponent } from './tv-rating-star.component';

describe('TvRatingStarComponent', () => {
  let component: TvRatingStarComponent;
  let fixture: ComponentFixture<TvRatingStarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TvRatingStarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TvRatingStarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
