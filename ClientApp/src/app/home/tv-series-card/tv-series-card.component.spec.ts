import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TvSeriesCardComponent } from './tv-series-card.component';

describe('TvSeriesCardComponent', () => {
  let component: TvSeriesCardComponent;
  let fixture: ComponentFixture<TvSeriesCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TvSeriesCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TvSeriesCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
