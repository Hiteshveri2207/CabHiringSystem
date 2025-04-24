import { Component } from '@angular/core';
import { DriverProfileService } from '../../service/driverprofile.service';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { StateService } from '../../service/state.service';
import { CommonModule } from '@angular/common';
import { CountryService } from '../../service/country.service';
import { environment } from '../../environment/environment';

@Component({
  selector: 'app-driverprofile',
  imports: [CommonModule, ReactiveFormsModule,FormsModule],
  templateUrl: './driverprofile.component.html',
  styleUrl: './driverprofile.component.css'
})
export class DriverProfileComponent {
  driverForm!: FormGroup;
  uploadedFiles: { [key: string]: File } = {};
  states: { id: number, name: string }[] = [] ;
   countries: any;
   imageUrl = environment.imageUploadUrl;

  constructor(private fb: FormBuilder, private driverProfileService: DriverProfileService, 
      private router: Router,private route :ActivatedRoute, private stateService: StateService, private countryService: CountryService)
      {
        
      }
      ngOnInit(): void {
        this.driverForm = this.fb.group({
          userId: ['', Validators.required],
          experience: [null],
          address: this.fb.group({
          addressLine1: ['', Validators.required],
          addressLine2: [''],
          city: ['', Validators.required],
          stateId: ['', Validators.required],
          countryId: ['', Validators.required],
          zipCode: ['', Validators.required]
          })
        });
    
        this.getStates();
        this.getCountry();
      }
    
      onFileChange(event: any, field: string): void {
        debugger;
        const file = event.target.files[0];
        if (file) {
          console.log(`Uploading ${field}:`, file);
          this.uploadedFiles[field] = file;
        } else {
          console.warn(`No file selected for ${field}`);
        }
      }
      
      onSubmit(): void {
        debugger;
        if (this.driverForm.invalid) {
          return;
        }
      
        const formData = new FormData();
        const formValue = this.driverForm.value;
      
        Object.keys(formValue).forEach(key => {
          const value = formValue[key];
      
          if (typeof value === 'object' && value !== null && !(value instanceof File)) {
            Object.keys(value).forEach(nestedKey => {
              formData.append(`${key}.${nestedKey}`, value[nestedKey]);
            });
          } else {
            formData.append(key, value);
          }
        });
      
        Object.keys(this.uploadedFiles).forEach(key => {
          formData.append(key, this.uploadedFiles[key]);
        });
      
        this.driverProfileService.adddriver(formData).subscribe({
          next: (res) => {
            Swal.fire({
              icon: 'success',
              title: 'Success',
              text: 'Driver profile created successfully!'
            });
          },
          error: (err) => {
            Swal.fire({
              icon: 'error',
              title: 'Oops...',
              text: 'Something went wrong while creating the driver profile.'
            });
            console.error('Error creating profile', err);
          }
        });
      }
      

    cancel()
  {
  this.driverForm.reset();
  
  }
  

  getStates() {
    this.stateService.getStates().subscribe((data: any) => {
      console.log("Received states:", data);
      this.states = data.sort((a: any, b: any) => a.name.localeCompare(b.name));
    });
  }
  
  getCountry() {
    this.countryService.getCountry().subscribe((data: any) => {
      console.log("?????????????????",data);
      this.countries = data;
    }); 
  
}
}
