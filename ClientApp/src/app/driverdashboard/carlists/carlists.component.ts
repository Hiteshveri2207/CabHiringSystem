import { Component, OnInit } from '@angular/core';
import { CarListsService } from '../../service/carlists.service';
import { Router, RouterModule } from '@angular/router';
import { map, Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import Swal from 'sweetalert2'; 


@Component({
  selector: 'app-carlists',
  // standalone: true, 
  imports: [CommonModule, RouterModule],
  templateUrl: './carlists.component.html',
  styleUrls: ['./carlists.component.css'] 
})
export class CarlistsComponent implements OnInit {
  cars: any[] = [];
    selectedCarId: number | null = null;
  brand: any[]=[];
  driver: any[]=[];
  totalCount: number = 0; 
pageSize: number = 3;  
pageNumber: number = 1;

   constructor( private carListsService: CarListsService, private router: Router)
{

}
ngOnInit(): void {
  this.getcars();
  }

  getcars(): void {
    this.carListsService.getcars(this.pageNumber, this.pageSize).subscribe({
      next: (response: any) => {
        this.cars = response.vehicle || [];  
        this.totalCount = response.totalCount || 0;
  
        console.log("Fetched cars:", this.cars);
        console.log("Total count:", this.totalCount);
      },
      error: (error) => {
        console.error("Error fetching cars:", error);
      }
    });
  }
    getTotalPages(): number {
      return Math.ceil(this.totalCount / this.pageSize);
    }
  
    onPageChange(newPage: number): void {
      if (newPage < 1 || newPage > this.getTotalPages()) return;
      this.pageNumber = newPage;
      this.getcars();
    }

editvehicle(Id: any) {
 
 this.router.navigate(['/driverdashboard/updatevehicle'], { queryParams: { Id: Id } });
}

deletecars(Id: string): void {
  Swal.fire({
    title: 'Are you sure?',
    text: 'Do you want to delete this car?',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonText: 'Yes, delete it!',
    cancelButtonText: 'Cancel',
    reverseButtons: true
  }).then((result) => {
    if (result.isConfirmed) {
      this.carListsService.deletecars(Id).subscribe({
        next: () => {
          Swal.fire(
            'Deleted!',
            'The car has been deleted successfully.',
            'success'
          );
          this.getcars(); 
        },
        error: (error) => {
          console.error('Error deleting car:', error);
          Swal.fire(
            'Error!',
            'There was an issue deleting the car. Please try again.',
            'error'
          );
        }
      });
    }
  });
}
}
