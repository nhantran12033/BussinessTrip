import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusinessTripComponent } from './business-trip.component';

describe('BusinessTripComponent', () => {
  let component: BusinessTripComponent;
  let fixture: ComponentFixture<BusinessTripComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BusinessTripComponent]
    });
    fixture = TestBed.createComponent(BusinessTripComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
