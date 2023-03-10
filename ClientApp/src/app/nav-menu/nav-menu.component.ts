import { HttpParams } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { ApiServiceService } from 'src/shared/services/api-service.service';
import { AuthenticationService } from 'src/shared/services/authentication.service';
import { LocalService } from 'src/shared/services/local-service.service';
import { TokenExpirationService } from 'src/shared/services/token-expiration.service';
import { UserService } from 'src/shared/services/user.service';
import { ActiveUser } from 'src/_interfaces/user/active-user.model';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
})
export class NavMenuComponent implements OnInit {
  public isUserAuthenticated: boolean;
  isExpanded = false;
  @Input() user: ActiveUser;
  @Output() newUser = new EventEmitter<ActiveUser>();
  @Output() logOutReload = new EventEmitter<boolean>();
  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private localService: LocalService,
    private tokenService: TokenExpirationService,
    private userService: UserService
  ) {}
  ngOnInit(): void {
    this.authService.authChanged.subscribe((res) => {
      const userString = this.localService.getData('user');
      if (userString) {
        const user = JSON.parse(userString) as ActiveUser;
        this.newUser.emit(user);
      }
      this.isUserAuthenticated = true;
    });
    if (this.user && this.user.firstName) {
      this.isUserAuthenticated = true;
    }
  }

  public logout = () => {
    this.authService.logout();
    this.isUserAuthenticated = false;
    this.localService.clearData();
    this.logOutReload.emit(false)
    this.router.navigate(['/']);
  };
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  getUser() {
    this.userService
      .getUser(this.user.id)
      .subscribe((res) => {
        console.log(res);
      });
  }

  getRecommendations() {
    this.router.navigate(['/recommendations'])
  }
}
