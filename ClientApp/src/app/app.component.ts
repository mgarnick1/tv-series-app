import { Component, OnInit } from '@angular/core';
import { LocalService } from 'src/shared/services/local-service.service';
import { TokenExpirationService } from 'src/shared/services/token-expiration.service';
import { ActiveUser } from 'src/_interfaces/user/active-user.model';
import { UserViewModel } from 'src/_interfaces/user/user.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  title = 'app';
  user: ActiveUser;
  isValidToken: boolean;

  constructor(private localService: LocalService, private tokenService: TokenExpirationService) {}

  ngOnInit(): void {
    const token = this.localService.getData('token')
    this.tokenService.revokeExpiredToken(token)
    const userString = this.localService.getData('user');
    if (userString) {
      this.user = JSON.parse(userString) as ActiveUser;
    }
  }

  setUser(event: ActiveUser) {
    this.user = event
  }

  reloadPageLogout(event: boolean) {
    if(!event) {
      window.location.reload()
    }
  }

}
