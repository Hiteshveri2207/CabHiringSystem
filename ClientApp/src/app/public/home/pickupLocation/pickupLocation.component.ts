import { Component } from '@angular/core';
import { CommonModule } from '@angular/common'; 

@Component({
  selector: 'app-pickup-location',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './pickupLocation.component.html',
  styleUrls: ['./pickupLocation.component.css']
})
export class pickupLocationComponent {
  fromCity: any[] = [];
  toCity: any[] = [];
  departureDate: Date | null = null;
  returnDate?: Date;
  pickupTime: string = '';
  meridiem: string = '';
  
}



