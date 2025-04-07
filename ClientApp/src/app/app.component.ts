import { Component } from '@angular/core';
import { Route, Router, RouterOutlet } from '@angular/router';
 import { HeaderComponent } from './shared/header/header.component';
 import { FooterComponent } from './shared/footer/footer.component';
import { FormsModule } from '@angular/forms';

import { CommonModule } from '@angular/common';
import { DriverfooterComponent } from './driverdashboard/driverfooter/driverfooter.component';
import { DriverheaderComponent } from './driverdashboard/driverheader/driverheader.component';
import { NavComponent } from './driverdashboard/nav/nav.component';


@Component({
  selector: 'app-root',
  
  imports: [RouterOutlet,
    HeaderComponent,
     FooterComponent,
     CommonModule, DriverfooterComponent , DriverheaderComponent ,
       NavComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Taxi-app';

  showHeaderFooter: boolean = true;
  constructor(private router: Router) {
    this.router.events.subscribe(() => {
      this.showHeaderFooter = !this.router.url.includes('driverdashboard');
    });
  }
}
