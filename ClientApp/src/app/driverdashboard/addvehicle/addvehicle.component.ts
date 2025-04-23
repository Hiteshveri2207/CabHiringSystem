import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AddVehicleService } from '../../service/addvehicle.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { BrandService } from '../../service/brand.service';
import Swal from 'sweetalert2';


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
    if (this.addVehicleForm.valid) {
      console.log(this.addVehicleForm.value);
      
      Swal.fire({
        icon: 'info',
        title: 'Submitting Form...',
        text: 'Please wait while we submit your vehicle data.',
        showConfirmButton: false,
        allowOutsideClick: false,
        willOpen: () => {
          Swal.showLoading();
        }
      });
  
      this.addVehicleService.addVehicle(this.addVehicleForm.value).subscribe({
        next: (response) => {
          console.log('Vehicle added:', response);
          Swal.fire({
            icon: 'success',
            title: 'Vehicle Added Successfully!',
            text: 'The vehicle has been added.',
            confirmButtonText: 'OK'
          }).then(() => {
            this.router.navigate(['/vehicle-list']); 
          });
        },
        error: (error) => {
          console.error('Error:', error);
          Swal.fire({
            icon: 'error',
            title: 'Submission Failed!',
            text: 'An error occurred while adding the vehicle. Please try again.',
            confirmButtonText: 'Retry'
          });
        }
      });
  
    } else {
      Swal.fire({
        icon: 'warning',
        title: 'Form Incomplete',
        text: 'Please complete all required fields before submitting.',
        confirmButtonText: 'OK'
      });
      this.addVehicleForm.markAllAsTouched(); 
    }
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
