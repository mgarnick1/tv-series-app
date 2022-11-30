import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTvSeriesComponent } from './add-tv-series.component';

describe('AddTvSeriesComponent', () => {
  let component: AddTvSeriesComponent;
  let fixture: ComponentFixture<AddTvSeriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddTvSeriesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddTvSeriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
