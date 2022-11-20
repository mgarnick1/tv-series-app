import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/shared/services/authentication.service';
import { LocalService } from 'src/shared/services/local-service.service';
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
  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private localService: LocalService
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
    this.router.navigate(['/']);
  };
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
