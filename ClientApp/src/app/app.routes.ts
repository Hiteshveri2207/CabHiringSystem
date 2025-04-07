import { Routes } from '@angular/router';
import { HomeComponent } from './public/home/home.component';
import { AboutComponent } from './public/about/about.component';
import { ServiceComponent } from './public/service/service.component';
import { ContactComponent } from './public/contact/contact.component';
import { BookRideComponent } from './public/book-ride/book-ride.component';
import { RegisterComponent } from './auth/register/register.component';
// import { signininComponent } from './auth/sign-in/sign-in.component';
import { LoginComponent } from './login/login.component';
import { CarListComponent } from './public/car-list/car-list.component';
// import { DashboardComponent } from './dashboard/dashboard.component';



export const routes: Routes = [

    {path:'',component:HomeComponent},
    {path:'Home',component:HomeComponent},
    {path:'about',component:AboutComponent},
    {path:'service',component:ServiceComponent},
    {path:'contact',component:ContactComponent},
    {path:'book-ride',component:BookRideComponent},
    {path:'register',component:RegisterComponent},
    {path:'car-list',component:CarListComponent},

    // {path:'sign-in',component:signininComponent},
    {path:'login',component:LoginComponent},
    // {path:'dashboard', component: DashboardComponent}
];
