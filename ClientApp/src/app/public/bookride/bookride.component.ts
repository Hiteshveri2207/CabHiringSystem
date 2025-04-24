import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { BookRideService } from '../../service/bookride.service';
import { Observable } from 'rxjs';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-bookRide',
  standalone: true,
  imports: [CommonModule, RouterModule, ReactiveFormsModule],
  templateUrl: './bookRide.component.html',
  styleUrls: ['./bookRide.component.css']
})
export class BookRideComponent implements OnInit {
  BookRide!: Observable<any[]>;
  bookRide: any;
  bookRideForm!: FormGroup;
  isSubmitting = false;
  returnDateVisible = true; 

  constructor(
    private fb: FormBuilder,
    private bookRideService: BookRideService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.bookRideForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      fromLocation: ['', Validators.required],
      toLocation: ['', Validators.required],
      tripType: ['', Validators.required],
      departureDate: ['', Validators.required],
      returnDate: [''],
      numberOfAdults: [],
      numberOfChildrens: [],
      numberOfInfants: [],
      additionalNotes: ['']
    });

    
    this.bookRideForm.get('tripType')?.valueChanges.subscribe(value => {
      if (value === 'oneWay') {
        this.returnDateVisible = false;
        this.bookRideForm.get('returnDate')?.setValue('');
        this.bookRideForm.get('returnDate')?.clearValidators();
        this.bookRideForm.get('returnDate')?.updateValueAndValidity();
      } else {
        this.returnDateVisible = true;
        this.bookRideForm.get('returnDate')?.setValidators([Validators.required]);
        this.bookRideForm.get('returnDate')?.updateValueAndValidity();
      }
    });
  }

  getbookride(): void {
    debugger;
    this.bookRideService.getRide().subscribe;
  }

  onSubmit(): void {
    debugger;

    if (this.bookRideForm.valid) {
      console.log(this.bookRideForm.value); 
      alert('Form Submitted');

      this.bookRideService.addRide(this.bookRideForm.value).subscribe({
        next: (response) => { console.log('user added:', response); },
        error: (error) => console.error("Error", error)
      });
    } else {
      alert('Form is not Valid');
    }
  }
}
