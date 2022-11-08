import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegistrationResponse } from 'src/_interfaces/responses/registration.response.model';
import { UserViewModel } from 'src/_interfaces/user/user.model';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  constructor(
    private http: HttpClient,
    private envUrl: EnvironmentUrlService
  ) {}

  public registerUser = (route: string, body: UserViewModel) => {
    debugger
    return this.http.post<RegistrationResponse>(
      this.createCompleteRoute(route, this.envUrl.urlAddress),
      body
    );
  };

  private createCompleteRoute = (route: string, urlAddress: string) => {
    return `${urlAddress}/${route}`;
  };
}
