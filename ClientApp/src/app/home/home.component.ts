import { Component, OnInit } from '@angular/core';
import { LocalService } from 'src/shared/services/local-service.service';
import { UserService } from 'src/shared/services/user.service';
import { TVSeries } from 'src/_interfaces/tv-series/tv-series.model';
import { ActiveUser } from 'src/_interfaces/user/active-user.model';
import { MatDialog } from '@angular/material/dialog';
import { AddTvSeriesComponent } from './add-tv-series/add-tv-series.component';
import { TVUser } from 'src/_interfaces/user/tv-user.model';

@Component({
  selector: 'app-home',
  styleUrls: ['./home.component.css'],
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  tvSeries: TVSeries[] = [];
  user: TVUser;
  displayedColumns: string[] = [
    'id',
    'showImage',
    'name',
    'description',
    'rating',
    'genre',
  ];

  constructor(
    private userService: UserService,
    private storage: LocalService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    const user = this.storage.getData('user');
    if (user) {
      const userObj = JSON.parse(user) as ActiveUser;
      this.userService.getUser(userObj.id).subscribe((res) => {
        this.tvSeries = res.tvSeries as TVSeries[];
        this.user = res;
      });
    }
  }
  openDialog() {
    const dialogRef = this.dialog.open(AddTvSeriesComponent, {
      width: '600px',
      data: { tvSeries: this.tvSeries, userId: this.user.id },
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.userService.getUser(this.user.id).subscribe((res) => {
        this.tvSeries = res.tvSeries as TVSeries[];
        this.user = res;
      });
    });
  }
}
