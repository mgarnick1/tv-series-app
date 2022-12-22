import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNetworkDialogComponent } from './add-network-dialog.component';

describe('AddNetworkDialogComponent', () => {
  let component: AddNetworkDialogComponent;
  let fixture: ComponentFixture<AddNetworkDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddNetworkDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddNetworkDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
