import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CustomernavComponent } from './customernav/customernav.component';
import { CustomerfooterComponent } from './customerfooter/customerfooter.component';
import { CustomerheaderComponent } from './customerheader/customerheader.component';
import { RideRequestsComponent } from './riderequests/riderequests.component';
import { RideHistoryComponent } from './ridehistory/ridehistory.component';


@Component({
  selector: 'app-customer-dashboard',
  standalone: true,
  imports: [
    // CustomerheaderComponent,
    // CustomerfooterComponent,
    // CustomernavComponent,
    // RideRequestsComponent,
   //  RideHistoryComponent
  ],
  templateUrl: './customerdashboard.component.html',
  styleUrl: './customerdashboard.component.css'
})
export class CustomerdashboardComponent {


}
