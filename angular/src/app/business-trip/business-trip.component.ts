import { ListService } from '@abp/ng.core';
import { Component, DoCheck, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TripInformationDto, TripInformationService } from '../proxy/trips';

@Component({
  selector: 'app-business-trip',
  templateUrl: './business-trip.component.html',
  styleUrls: ['./business-trip.component.scss'],
  providers: [ListService]
})
export class BusinessTripComponent implements OnInit, DoCheck {
  tripDto: TripInformationDto[]
  islisting = true;
  constructor(
    private trip: TripInformationService,
    private router: Router,
    private route: ActivatedRoute,
  ) { }
  ngOnInit() {
    this.trip.getTripInformation().subscribe((response) => {
      this.tripDto = response;
    })
    this.route.url.subscribe(() => {
      this.trip.getTripInformation().subscribe((response) => {
        this.tripDto = response;
      })
    })
  }
  ngDoCheck(): void {
    let currenturl = this.router.url;
    if (currenturl == '/businessTrip') {
      this.islisting = true;
    } else {
      this.islisting = false;
    }
  }
  Edit(id: any) {
    this.router.navigate(['businessTrip/edit/' + id])
  }
  delete(id: any) {
    this.trip.deleteList(id).subscribe(response => {
      this.ngOnInit();
    })
  }
}
