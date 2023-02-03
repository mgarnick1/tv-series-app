import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmailRecommendationComponent } from './email-recommendation.component';

describe('EmailRecommendationComponent', () => {
  let component: EmailRecommendationComponent;
  let fixture: ComponentFixture<EmailRecommendationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmailRecommendationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmailRecommendationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
