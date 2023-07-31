import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BusinessTripComponent } from './business-trip.component';

const routes: Routes = [{ path: '', component: BusinessTripComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BusinessTripRoutingModule { }
