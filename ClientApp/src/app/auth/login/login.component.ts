import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { RegisterService } from '../../service/register.service';

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
          alert(" User LogIn Successfully ");
          this.router.navigate(['/home']); 
        },
        error: (error) => {
          console.error('Login error:', error);
          alert(" Please Try Again ");
        }
      });
    } else {
      console.warn('Login form is invalid');
      alert("Login form is invalid");
      this.loginForm.markAllAsTouched(); 
    }
  }
}