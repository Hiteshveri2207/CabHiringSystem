import { Component, DebugElement, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ridesService } from '../../service/rides.service';
import { map, Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import Swal from 'sweetalert2';
import { bookingstatusService } from '../../service/bookingstatus.service';


@Component({
  selector: 'app-rides',
  imports: [CommonModule, RouterModule],
  templateUrl: './rides.component.html',
  styleUrl: './rides.component.css',
  standalone: true,
})
export class RidesComponent  {
   rides$!: Observable<any[]>;
   rides: any[] = [] ;
   customer: any[]=[];
   bookingId: any | null = null;
   statuses : any[]=[];
  constructor( private ridesService: ridesService, private router: Router,private route: ActivatedRoute,
     private bookingStatusService : bookingstatusService)
{

}
ngOnInit(): void {
  this.GetStatuses();
this.getRides();
const bookingId= this.route.snapshot.params['id'];
this.bookingId = bookingId

}

getRides(): void {
  
 this.ridesService.getRides().subscribe({
  next: (response) => {
    this.rides = Array.isArray(response) ? response : (response as any).data;
    console.log(this.rides);
  },
  error:(error) => console.error('Error Fetching rides', error)
 })
}
GetStatuses()
{
  this.bookingStatusService.GetStatuses().subscribe(
    (statuses)=>{
    this.statuses=statuses;
    console.log('Statuses from API:', statuses);
    },
  )
}
getStatusById(statusName: string): number | null {

  const status = this.statuses.find((status) => status.statusName === statusName);
  return status ? status.id : null;
}

updateBookingStatus(rides: any, action: string): void {
  debugger;
  console.log('Ride object:', rides);  
  console.log('Available statuses:', this.statuses);
  console.log('Action:', action);

  const statusId = this.getStatusById(action); 

  if (!statusId) {
    Swal.fire('Error!', `Status ID not found for the action: ${action}`, 'error');
    return;
  }

  if (!rides?.id) {
    Swal.fire('Error!', 'Ride ID is missing or invalid!', 'error');
    console.log('rides.id:', rides?.id);
    return;
  }

  Swal.fire({
    title: 'Are you sure?',
    text: `You are about to ${action} this Booking.`,
    icon: 'warning',
    showCancelButton: true,
    confirmButtonText: 'Yes, do it!',
    cancelButtonText: 'Cancel'
  }).then((result) => {
    if (result.isConfirmed) {
      this.ridesService.UpdateStatus(rides.id, statusId).subscribe(
        () => {
          Swal.fire(
            'Success!',
            `${action} request status update successfully.`,
            'success'
          );
          this.getRides();
        },
        (error) => {
          Swal.fire(
            'Error!',
            `${action} request status failed: ${error.message || error}`,
            'error'
          );
        }
      );
    }
  });
}
}