import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { ridehistoryService } from '../../service/ridehistory.service';


@Component({
  selector: 'app-ridehistory',
  templateUrl: './ridehistory.component.html',
  styleUrls: ['./ridehistory.component.css'],
  imports: [CommonModule, RouterModule],
  standalone: true,
})
export class RideHistoryComponent implements OnInit {
  rideHistory$!: Observable<any[]>;

  fromLocation: string = '';
  toLocation: string = '';
  selectTripType: string = '';
  departureDate: string = '';
  returnDate: string = '';
  numberOfAdults: number = 0;
  numberOfChildren: number = 0;
  numberOfInfants: number = 0;
  additionalNotes: string = '';
  

  constructor(private rideHistoryService: ridehistoryService, private router: Router) {}

  ngOnInit(): void {
    this.getAll();
  }

  getAll(): void {
    debugger; 
    this.rideHistory$ = this.rideHistoryService.getAll();
  }
}
