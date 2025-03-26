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
      email: ['', [Validators.required, Validators.email]], // Email validation
      password: ['', [Validators.required, Validators.minLength(6)]]  // Password validation
    });

  }
  onSubmit(): void {
    alert('Form Submitted');
    if (this.loginForm.valid) {
      console.log(this.loginForm.value);
    }
    this.registerService.SignIn(this.loginForm.value).subscribe({
      next: (response) => { console.log('user added:', response); },
      error: (error) => console.error("Error", error)
    });
  }
  login() {
    console.log("inside login");

    this.router.navigate(['Home']);
  }
}
