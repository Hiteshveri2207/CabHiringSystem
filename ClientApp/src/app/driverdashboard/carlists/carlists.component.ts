import { Component, OnInit } from '@angular/core';
import { CarListsService } from '../../service/carlists.service';
import { Router, RouterModule } from '@angular/router';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-carlists',
  standalone: true, 
   imports: [CommonModule, RouterModule],
  templateUrl: './carlists.component.html',
  styleUrls: ['./carlists.component.css'] 
})
export class CarlistsComponent implements OnInit {
  cars$!: Observable<any[]>;
  selectedCarId: number | null = null;
  brand: any[]=[];
  driver: any[]=[];
   constructor( private carListsService: CarListsService, private router: Router)
{}
ngOnInit(): void {
  this.getcars();
}

getcars(): void {
  this.cars$ = this.carListsService.getcars(); 
}
editvehicle(Id: any) {
  debugger;
 this.router.navigate(['/driverdashboard/updatevehicle'], { queryParams: { Id: Id } });
}
deletecars(Id: string): void {
  
  if (confirm('Are you sure you want to delete this cars?')) {
    this.carListsService.deletecars(Id).subscribe({
      next: () => {
        this.getcars();
      },
      error: (error) => {
        console.error('Error deleting cars:', error);
        alert('Error deleting cars. Please try again.');
      }
    });
  } 
}
}
