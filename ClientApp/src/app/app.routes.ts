import { Routes } from '@angular/router';
import { HomeComponent } from './public/home/home.component';
import { AboutComponent } from './public/about/about.component';
import { ServiceComponent } from './public/service/service.component';
import { ContactComponent } from './public/contact/contact.component';
import { BookRideComponent } from './public/bookride/bookride.component';
import { RegisterComponent } from './auth/register/register.component';
import { LoginComponent } from './auth/login/login.component';
import { DriverfooterComponent } from './driverdashboard/driverfooter/driverfooter.component';
import { NavComponent } from './driverdashboard/nav/nav.component';
import { DriverheaderComponent } from './driverdashboard/driverheader/driverheader.component';
import { DriverdashboardComponent } from './driverdashboard/driverdashboard.component';
import { AddvehicleComponent } from './driverdashboard/addvehicle/addvehicle.component';
import { CarlistsComponent } from './driverdashboard/carlists/carlists.component';
import { UpdateVehicleComponent } from './driverdashboard/updatevehicle/updatevehicle.component';
import { pickupLocationComponent } from './public/home/pickupLocation/pickupLocation.component';
import { LocationsearchComponent } from './public/home/locationsearch/locationsearch.component';
import { CarListComponent } from './public/carlist/carlist.component';
import { CustomerheaderComponent } from './customerdashboard/customerheader/customerheader.component';
import { CustomerfooterComponent } from './customerdashboard/customerfooter/customerfooter.component';
import { CustomerdashboardComponent } from './customerdashboard/customerdashboard.component';
import { CustomernavComponent } from './customerdashboard/customernav/customernav.component';
import { RideRequestsComponent } from './customerdashboard/riderequests/riderequests.component';
import { RideHistoryComponent } from './customerdashboard/ridehistory/ridehistory.component';
import { RidesComponent } from './driverdashboard/rides/rides.component';
import { DriverProfileComponent } from './driverdashboard/driverprofile/driverprofile.component';




export const routes: Routes = [
    {path:'',component:HomeComponent},
    {path:'home',component:HomeComponent},
    {path:'about',component:AboutComponent},
    {path:'service',component:ServiceComponent},
    {path:'contact',component:ContactComponent},
    {path:'bookride',component:BookRideComponent},
    {path:'register',component:RegisterComponent},
    {path:'login',component:LoginComponent},
    {path:'driverdashboard/driverheader',component:DriverheaderComponent},
    {path:'driverdashboard/driverfooter',component:DriverfooterComponent},
    {path:'driverdashboard/nav',component:NavComponent},
    {path:'driverdashboard',component:DriverdashboardComponent},
    {path:'driverdashboard/addvehicle',component:AddvehicleComponent},
    {path:'driverdashboard/carlists',component:CarlistsComponent},
    {path:'driverdashboard/updatevehicle',component:UpdateVehicleComponent}
];
