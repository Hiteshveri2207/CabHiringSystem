import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { riderequestService } from '../../service/riderequest.service';


@Component({
  selector: 'app-riderequests',
  templateUrl: './riderequests.component.html',
  styleUrls: ['./riderequests.component.css'],
  imports: [CommonModule, RouterModule],
  standalone: true, 
})
export class RideRequestsComponent implements OnInit {
  rideRequests$!: Observable<any[]>;
  fromLocation: string = '';
  toLocation: string = '';
  selectTripType: string = '';
  departureDate: string = '';
  returnDate: string = '';
  numberOfAdults: number = 0;
  numberOfChildren: number = 0;
  numberOfInfants: number = 0;
  additionalNotes: string = '';
  status:string='';
  constructor(private riderequestService: riderequestService, private router: Router) {}

  ngOnInit(): void {
    this.getAll();
  }

  getAll(): void {
   debugger;
    this. rideRequests$! = this.riderequestService.getAll(); 
  }
}
