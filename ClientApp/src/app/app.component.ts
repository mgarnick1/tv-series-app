import { Component, OnInit } from '@angular/core';
import { LocalService } from 'src/shared/services/local-service.service';
import { ActiveUser } from 'src/_interfaces/user/active-user.model';
import { UserViewModel } from 'src/_interfaces/user/user.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  title = 'app';
  user: ActiveUser;

  constructor(private localService: LocalService) {}

  ngOnInit(): void {
    const userString = this.localService.getData('user');
    if (userString) {
      this.user = JSON.parse(userString) as ActiveUser;
    }
  }
}
