import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BusinessTripRoutingModule } from './business-trip-routing.module';
import { BusinessTripComponent } from './business-trip.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    BusinessTripComponent
  ],
  imports: [
    CommonModule,
    BusinessTripRoutingModule,
    SharedModule
  ]
})
export class BusinessTripModule { }
