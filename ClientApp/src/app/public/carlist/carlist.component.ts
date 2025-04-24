import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

import { CommonModule } from '@angular/common';
import { carListService } from '../../service/carlist.service';
import { map, Observable } from 'rxjs';

@Component({
  selector: 'app-carlist',
 
  imports: [CommonModule, RouterModule],
  templateUrl: './carlist.component.html',
  styleUrls: ['./carlist.component.css'] 
})
export class CarListComponent implements OnInit {
  cars$!: Observable<any[]>;
  selectedCarId: number | null = null;
  brand: any[]=[];
  driver: any[]=[];
  constructor( private carListService : carListService ,router: Router)
{

}
ngOnInit(): void {
  this.cars$ = this.carListService.getcar().pipe(
    map((res: any) => res.vehicle) // import 'map' from 'rxjs/operators'
  );
}


getcar(): void {
  debugger;
  this.cars$ = this.carListService.getcar(); 
}
  };
