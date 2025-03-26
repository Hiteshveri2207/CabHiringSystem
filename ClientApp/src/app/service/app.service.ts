import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class AppService {
    public user: any = null;
    private apiUrl = 'https://localhost:7272/api/auth'; 
  toastr: any;
    constructor(
        private http: HttpClient,
        private router: Router,
        
    ) {}

    async registerUser(firstName: string, lastName: string, email: string, password: string, confirmPassword: string, phoneNumber: string, role: string) {
        try {
            const result: any = await this.http.post(`${this.apiUrl}/Register`, { 
                firstName, 
                lastName, 
                email, 
                password, 
                confirmPassword, 
                phoneNumber, 
                 
            }).toPromise();
            
            this.user = result;
            localStorage.setItem('token', result.token); // Store JWT Token
            this.router.navigate(['/']);
            return result;
        } catch (error: any) {
            this.toastr.error(error.error.message || 'Registration failed');
        }
    }
    

    async SignInWithEmail(email: string, password: string) {
        try {
            const result: any = await this.http.post(`${this.apiUrl}/SignIn`, { email, password }).toPromise();
            this.user = result;
            localStorage.setItem('token', result.token); // Store JWT Token
            this.router.navigate(['/']);
            return result;
        } catch (error: any) {
            this.toastr.error(error.error.message || 'sign-in failed');
        }
    }

    async getProfile() {
        try {
            const token = localStorage.getItem('token');
            if (!token) {
                this.SignOut();
                return;
            }

            const user = await this.http.get(`${this.apiUrl}/profile`, {
                headers: { Authorization: `Bearer ${token}` }
            }).toPromise();

            this.user = user;
        } catch (error: any) {
            this.SignOut();
            this.toastr.error(error.error.message || 'Failed to fetch profile');
        }
    }

    async SignOut() {
        localStorage.removeItem('token');
        this.user = null;
        this.router.navigate(['/Sign-in']);
    }
}
