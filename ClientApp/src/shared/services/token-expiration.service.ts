import { Injectable } from '@angular/core';
import jwtDecode from 'jwt-decode';
import { ActiveUser } from 'src/_interfaces/user/active-user.model';
import { UserViewModel } from 'src/_interfaces/user/user.model';
import { LocalService } from './local-service.service';
import { DateTime } from 'luxon';

@Injectable({
  providedIn: 'root',
})
export class TokenExpirationService {
  constructor(private storage: LocalService) {}

  public isTokenExpired(token: string | null): boolean {
    let isValid = false
    if (token) {
      const decoded = jwtDecode<ActiveUser>(token);
      const now = Date.now();
      const tokenExpiration = decoded.exp * 1000;
      if (now > tokenExpiration) {
        isValid = false;
      } else {
        isValid = true;
      }
    }
    return isValid;
  }

  public revokeExpiredToken(token: string | null) {
    let tokenExpired
    if(token) {
      tokenExpired = this.isTokenExpired(token)
      if(!tokenExpired) {
        this.storage.removeData('token')
        this.storage.removeData('user')
      }
    }
  } 
}
