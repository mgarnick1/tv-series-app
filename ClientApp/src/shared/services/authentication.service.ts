import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { AuthenticationResponse } from 'src/_interfaces/responses/auth.response.model';
import { RegistrationResponse } from 'src/_interfaces/responses/registration.response.model';
import { LoginModel } from 'src/_interfaces/user/login.model';
import { UserViewModel } from 'src/_interfaces/user/user.model';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  private authChangeState = new Subject<boolean>();
  public authChanged = this.authChangeState.asObservable();
  constructor(
    private http: HttpClient,
    private envUrl: EnvironmentUrlService
  ) {}

  public registerUser = (route: string, body: UserViewModel) => {
    return this.http.post<RegistrationResponse>(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      body
    );
  };

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this.authChangeState.next(isAuthenticated);
  }

  public logout = () => {
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false);
  }

  private createCompleteRoute = (route: string, urlAddress: string) => {
    return `${urlAddress}/${route}`;
  };

  public loginUser = (route: string, body: LoginModel) => {
    return this.http.post<AuthenticationResponse>(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      body
    );
  };
}
