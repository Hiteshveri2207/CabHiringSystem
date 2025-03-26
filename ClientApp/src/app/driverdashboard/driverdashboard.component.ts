import { Component } from '@angular/core';
import { DriverfooterComponent } from './driverfooter/driverfooter.component';
import { DriverheaderComponent } from './driverheader/driverheader.component';
import { NavComponent } from './nav/nav.component';


@Component({
  selector: 'app-driverdashboard',
  standalone: true,
  imports: [DriverheaderComponent, NavComponent, DriverfooterComponent],
  templateUrl: './driverdashboard.component.html',
  styleUrl: './driverdashboard.component.css'
})
export class DriverdashboardComponent {

}
