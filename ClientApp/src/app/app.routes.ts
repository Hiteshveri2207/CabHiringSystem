import { Routes } from '@angular/router';
import { HomeComponent } from './public/home/home.component';
import { AboutComponent } from './public/about/about.component';
import { ServiceComponent } from './public/service/service.component';
import { ContactComponent } from './public/contact/contact.component';
import { BookRideComponent } from './public/book-ride/book-ride.component';
import { RegisterComponent } from './auth/register/register.component';
import { LoginComponent } from './auth/login/login.component';
import { DriverfooterComponent } from './driverdashboard/driverfooter/driverfooter.component';
import { NavComponent } from './driverdashboard/nav/nav.component';
import { DriverheaderComponent } from './driverdashboard/driverheader/driverheader.component';
import { DriverdashboardComponent } from './driverdashboard/driverdashboard.component';



export const routes: Routes = [
  

    {path:'',component:HomeComponent},
    {path:'Home',component:HomeComponent},
    {path:'about',component:AboutComponent},
    {path:'service',component:ServiceComponent},
    {path:'contact',component:ContactComponent},
    {path:'book-ride',component:BookRideComponent},
    {path:'register',component:RegisterComponent},
    {path:'login',component:LoginComponent},
    {path:'header',component:DriverheaderComponent},
    {path:'footer',component:DriverfooterComponent},
    {path:'nav',component:NavComponent},
    {path:'driverdashboard',component:DriverdashboardComponent}
];
