import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TvApiService } from 'src/shared/services/tv-api.service';
import { EmailRecommendation } from 'src/_interfaces/tv-series/email-recommendation.model';
import { TVSeries } from 'src/_interfaces/tv-series/tv-series.model';

export class EmailRecommendationComponentDialog {
  from: string;
  friendName: string;
  networkName: string;
  tvSeries: TVSeries;
}

@Component({
  selector: 'app-email-recommendation',
  templateUrl: './email-recommendation.component.html',
  styleUrls: ['./email-recommendation.component.css'],
})
export class EmailRecommendationComponent implements OnInit {
  to: string = '';
  from: string = '';
  friendName: string = '';
  networkName: string = '';
  email: EmailRecommendation = {
    to: '',
    from: '',
    subject: '',
    friendName: '',
    series: '',
    network: '',
    image: '',
  };
  constructor(
    public dialogRef: MatDialogRef<EmailRecommendationComponent>,
    @Inject(MAT_DIALOG_DATA) public data: EmailRecommendationComponentDialog,
    private tvService: TvApiService
  ) {}

  ngOnInit(): void {
    this.from = this.data.from || '';
    this.friendName = this.data.friendName || '';
    this.email.from = this.from;
    this.networkName = this.data.networkName || '';
    this.email.friendName = this.friendName;
    this.email.series = this.data.tvSeries?.name;
    this.email.network = this.networkName;
    this.email.subject = 'Check out this new tv series';
    this.email.image = this.data.tvSeries.showImage;
  }

  close() {
    this.dialogRef.close();
  }

  sendEmail() {
    if (this.to) {
      this.email.to = this.to;
      this.tvService.sendRecommendation(this.email).subscribe(
        (res) => {
          if (res) {
            this.to = '';
            this.email.to = '';
            this.email.from = '';
            this.email.subject = '';
            this.email.friendName = '';
            this.email.series = '';
            this.email.network = '';
            this.email.image = '';
          }
          this.dialogRef.close();
        },
        (e) => {
          console.log('Failed to send email recommendation', e);
        }
      );
    }
  }
}
