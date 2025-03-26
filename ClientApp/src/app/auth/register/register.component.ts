import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../../service/register.service';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { RoleService } from '../../service/role.service';
import { Router } from '@angular/router';

@Component({

  selector: 'app-register',
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],  
})
export class RegisterComponent {
  registerForm: FormGroup;
  selectedRole: number | null = null;
  roles: { id: number, name: string }[] = []
  constructor(private fb: FormBuilder,private registerService:RegisterService,
    private http: HttpClient, private roleService: RoleService, private router: Router) {
   
    this.registerForm= this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(3)]], // First Name validation
      lastName: ['', [Validators.required, Validators.minLength(3)]], // Last Name validation
      role: ['', [Validators.required]], // Role validation
      phoneNumber: ['', [Validators.required,Validators.pattern('^[0-9]{10}$')]], // Phone Number validation  
      email: ['', [Validators.required, Validators.email]], // Email validation
      password: ['', [Validators.required, Validators.minLength(6)]] , // Password validation
      confirmPassword: ['', [Validators.required, Validators.minLength(6)]] , // Confirm Password validation
     
    });
  }
   ngOnInit() {
    this.getRoles();
  }
  getRoles() {
    debugger;
    this.roleService.getRoles().subscribe(
      (data) => {
        this.roles = data;
      },
      (error) => {
        console.error('Error fetching roles:', error);
      }
    );
  }
  
  onSubmit(): void {

alert('Form Submitted');
      this.router.navigate([`/login`]);
        if (this.registerForm.valid) {
          console.log(this.registerForm.value); 
        }
        this.registerService.register(this.registerForm.value).subscribe({
          next: (response) => { console.log('user added:', response); } ,
          error: (error) => console.error("Error", error) });
  } 
  
  navigateToLogin() {
    this.router.navigate(['/login']);
  }
}