import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { UpdateVehicleService } from '../../service/updatevehicle.service';
import { Observable } from 'rxjs';
import { BrandService } from '../../service/brand.service';
import Swal from 'sweetalert2'; // Ensure SweetAlert2 is imported at the top



@Component({
  selector: 'app-updatevehicle',
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './updatevehicle.component.html',
  standalone:true,
  styleUrls: ['./updatevehicle.component.css']
})
export class UpdateVehicleComponent {
  updateVehicleForm: FormGroup;
  vehicle$ : any;
  isSubmitting = false;
  driverVehicleId : any;
  VehicleToEdit:any;
  brand: any[] = [];
  driver: any[]=[];
  
  constructor(private fb: FormBuilder, private updateVehicleService: UpdateVehicleService, 
    private router: Router,private route :ActivatedRoute,
    private brandService: BrandService
  ) {
    this.updateVehicleForm = this.fb.group({
      driverId: ['', Validators.required],
      brandId: ['', Validators.required],
      vehicleModel: ['', Validators.required],
      vehicleNumber: ['', Validators.required],
      modelYear: ['', Validators.required],
      seatingCapacity: ['', [Validators.required]]
    });
    this.loadVehicleDetails();
  }

ngOnInit(): void {
  this.loadvehicle();
    this.route.queryParams.subscribe(params => {
    this.driverVehicleId  = params['Id'];})
  this.loadVehicleDetails();
  this.getBrand();
}    

loadVehicleDetails(): void {

  this.updateVehicleService.getById(this.driverVehicleId).subscribe(

    (vehicle) => {
      this.VehicleToEdit = vehicle;

      this.updateVehicleForm.patchValue({
        driverId: vehicle.driverId,
        brandId: vehicle.brandId,
        vehicleModel: vehicle.vehicleModel,
        vehicleNumber: vehicle.vehicleNumber,  
        modelYear: vehicle.modelYear,
        seatingCapacity: vehicle.seatingCapacity
      });
    },
  );
}

updatevehicle(formData: any): void {
  this.updateVehicleService.updatevehicle(this.driverVehicleId, formData).subscribe({
    next: (response) => {
      console.log("Vehicle updated successfully!", response);
      Swal.fire({
        icon: 'success',
        title: 'Vehicle Updated!',
        text: 'The vehicle details were updated successfully.',
        confirmButtonText: 'OK'
      });
    },
    error: (error) => {
      console.error("Error updating vehicle:", error);
      Swal.fire({
        icon: 'error',
        title: 'Update Failed',
        text: 'Failed to update vehicle. Please check the console for details.',
        confirmButtonText: 'Retry'
      });
    }
  });
}


onSubmit(): void {
  if (this.updateVehicleForm.invalid || !this.driverVehicleId) {
    console.error("Form is invalid or vehicleId is missing");
    return;
  }

  const formData = this.updateVehicleForm.value;
  console.log("Submitting vehicle update:", formData);

  this.updatevehicle(formData);
}

  loadvehicle(): void {
    this.vehicle$ = this.updateVehicleService.getById(this.driverVehicleId);
  }

getBrand() {
  this.brandService.getBrand().subscribe(data => {
    console.log("?????????????????",data);
    this.brand = data;
  }); 
}
}