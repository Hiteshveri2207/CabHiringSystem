import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { RegisterService } from '../../service/register.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;
  constructor(private fb: FormBuilder, private registerService: RegisterService, private router: Router) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]], 
      password: ['', [Validators.required, Validators.minLength(6)]] 
    });
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      console.log(this.loginForm.value);
  
      this.registerService.LogIn(this.loginForm.value).subscribe({
        next: (response) => {
          console.log('User logged in:', response);
          Swal.fire({
            icon: 'success',
            title: 'Login Successful',
            text: 'User logged in successfully!',
            confirmButtonText: 'Continue'
          }).then(() => {
            this.router.navigate(['/home']);
          });
        },
        error: (error) => {
          console.error('Login error:', error);
          Swal.fire({
            icon: 'error',
            title: 'Login Failed',
            text: 'Please try again.',
            confirmButtonText: 'Retry'
          });
        }
      });
  
    } else {
      console.warn('Login form is invalid');
      Swal.fire({
        icon: 'warning',
        title: 'Invalid Form',
        text: 'Please correct the errors and try again.',
        confirmButtonText: 'OK'
      });
      this.loginForm.markAllAsTouched(); 
    }
  }
}  