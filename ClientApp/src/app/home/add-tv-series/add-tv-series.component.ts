import { Component, Inject, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TvApiService } from 'src/shared/services/tv-api.service';
import { TVSeries } from 'src/_interfaces/tv-series/tv-series.model';

export class AddTvSeriesComponentDialog {
  tvSeries: TVSeries;
  userId: string;
}

@Component({
  selector: 'app-add-tv-series',
  templateUrl: './add-tv-series.component.html',
  styleUrls: ['./add-tv-series.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class AddTvSeriesComponent implements OnInit {
  form: FormGroup;
  name: string;
  userId: string;
  showImage: string;
  description: string;
  genre: string;
  rating: number;

  isNew: boolean = true;

  constructor(
    public dialogRef: MatDialogRef<AddTvSeriesComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AddTvSeriesComponentDialog,
    private fb: FormBuilder,
    private tvService: TvApiService
  ) {}

  ngOnInit(): void {
    this.userId = this.data.userId;
    this.isNew = this.data?.tvSeries === null;
    this.form = this.fb.group({
      name: [this.name, []],
      showImage: [this.showImage, []],
      description: [this.description, []],
      genre: [this.genre, []],
      rating: [this.rating, []],
    });
    if (!this.isNew && this.data?.tvSeries?.id) {
      this.form.setValue({
        name: this.data.tvSeries.name,
        showImage: this.data.tvSeries.showImage,
        description: this.data.tvSeries.description,
        genre: this.data.tvSeries.genre,
        rating: this.data.tvSeries.rating,
      });
    }
  }
  close() {
    this.dialogRef.close();
  }
  save() {
    console.log(this.form.value);
    const tvSeries = this.form.value as TVSeries;
    tvSeries.userId = this.userId;
    if (this.isNew) {
      this.tvService.createTVSeries(tvSeries).subscribe((res) => {
        this.dialogRef.close();
      });
    } else {
      tvSeries.id = this.data.tvSeries.id;
      this.tvService.editTVSeries(tvSeries).subscribe((res) => {
        this.dialogRef.close();
      });
    }
  }
}
