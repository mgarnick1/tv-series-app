import { Component, HostListener, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { LocalService } from 'src/shared/services/local-service.service';
import { NetworkService } from 'src/shared/services/network.service';
import { TvApiService } from 'src/shared/services/tv-api.service';
import { UserService } from 'src/shared/services/user.service';
import { TVSeries } from 'src/_interfaces/tv-series/tv-series.model';
import { ActiveUser } from 'src/_interfaces/user/active-user.model';
import { TVUser } from 'src/_interfaces/user/tv-user.model';
import { AddTvSeriesComponent } from '../home/add-tv-series/add-tv-series.component';

@Component({
  selector: 'app-recommendations',
  templateUrl: './recommendations.component.html',
  styleUrls: ['./recommendations.component.css'],
})
export class RecommendationsComponent implements OnInit {
  tvSeries: TVSeries[] = [];
  user: TVUser;
  page = 1;
  fetching: boolean = false;

  constructor(
    private userService: UserService,
    private storage: LocalService,
    private tvService: TvApiService,
    private networkService: NetworkService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    const user = this.storage.getData('user');
    if (user) {
      const userObj = JSON.parse(user) as ActiveUser;
      this.userService.getUser(userObj.id).subscribe((res) => {
        this.user = res;
        this.tvService
          .getRecommendations(this.page, this.user.id)
          .subscribe((res) => {
            this.tvSeries = res as TVSeries[];
          });
      });
    }
  }

  AddShow(show: TVSeries) {
    const dialogRef = this.dialog.open(AddTvSeriesComponent, {
      width: '600px',
      data: { tvSeries: show, userId: this.user.id, recommendation: true },
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.tvService
        .getRecommendations(this.page, this.user.id)
        .subscribe((res) => {
          this.tvSeries = res as TVSeries[];
        });
    });
  }

  getNextRecommendations(): void {
    this.fetching = !this.fetching;
    this.page++;
    this.tvService
      .getRecommendations(this.page, this.user.id)
      .subscribe((res) => {
        const newRecommendations = res as TVSeries[];
        const allRecommendations = this.tvSeries.concat(newRecommendations);
        this.tvSeries = allRecommendations;
        this.fetching = !this.fetching;
      });
  }

  sendEmail(tvSeries: TVSeries) {
  }
}
