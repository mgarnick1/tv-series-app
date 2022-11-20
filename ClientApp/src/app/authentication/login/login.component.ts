import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { AuthenticationResponse } from 'src/_interfaces/responses/auth.response.model';
import { UserViewModel } from 'src/_interfaces/user/user.model';
import { LoginModel } from 'src/_interfaces/user/login.model';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from 'src/shared/services/authentication.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { LocalService } from 'src/shared/services/local-service.service';
import jwtDecode from 'jwt-decode';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  private returnUrl: string = '';
  loginForm: FormGroup;
  errorMessage: string = '';
  showError: boolean;

  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private route: ActivatedRoute,
    private localService: LocalService
  ) {}

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
    });
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  validateControl = (controlName: string) => {
    return (
      this.loginForm.get(controlName)?.invalid &&
      this.loginForm.get(controlName)?.touched
    );
  };

  hasError = (controlName: string, errorName: string) => {
    return this.loginForm.get(controlName)?.hasError(errorName);
  };

  loginUser = (loginFormValue: any) => {
    this.showError = false;
    const login = { ...loginFormValue };

    const user: LoginModel = {
      email: login.username,
      password: login.password,
    };
    this.authService.loginUser('api/authorize/login', user).subscribe({
      next: (res: AuthenticationResponse) => {
        this.localService.saveData('token', res.token);
        const user = jwtDecode(res.token);
        this.localService.saveData('user', JSON.stringify(user))
        this.authService.sendAuthStateChangeNotification(res.isAuthSuccessful);
        this.router.navigate([this.returnUrl]);
      },
      error: (err: HttpErrorResponse) => {
        this.errorMessage = err.message;
        this.showError = true;
      },
    });
  };
}
