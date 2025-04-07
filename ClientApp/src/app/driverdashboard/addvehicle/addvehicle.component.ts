import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AddVehicleService } from '../../service/addvehicle.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { BrandService } from '../../service/brand.service';


@Component({
  selector: 'app-addvehicle',
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './addvehicle.component.html',
  styleUrls: ['./addvehicle.component.css']
})
export class AddvehicleComponent {
  addVehicleForm: FormGroup;
  isSubmitting = false;
  brand: any[] = [];
 

  constructor(private fb: FormBuilder, private addVehicleService: AddVehicleService, 
    private router: Router,
     private brandService : BrandService) {
    this.addVehicleForm = this.fb.group({
      driverId: ['', Validators.required],
      brandId: ['', Validators.required],
      vehicleModel: ['', Validators.required],
      vehicleNumber: ['', Validators.required],
      modelYear: ['', Validators.required],
      seatingCapacity: ['', [Validators.required]]
    });
    
  }
  cancel()
  {
  this.addVehicleForm.reset();
  
  }
  onSubmit(): void {

    alert('Form Submitted');
          this.router.navigate([]);
            if (this.addVehicleForm.valid) {
              console.log(this.addVehicleForm.value); 
            }
            this.addVehicleService.addVehicle(this.addVehicleForm.value).subscribe({
              next: (response) => { console.log('user added:', response); } ,
              error: (error) => console.error("Error", error) });
  } 
  ngOnInit(): void {
    this.getBrand();
  }

  getBrand() {
    this.brandService.getBrand().subscribe(data => {
      console.log("?????????????????",data);
      this.brand = data;
    }); 
  
}
}
