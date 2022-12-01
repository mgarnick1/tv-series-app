import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TVSeries } from 'src/_interfaces/tv-series/tv-series.model';

export class AddTvSeriesComponentDialog {
  tvSeries: TVSeries;
  userId: string;
}

@Component({
  selector: 'app-add-tv-series',
  templateUrl: './add-tv-series.component.html',
  styleUrls: ['./add-tv-series.component.css'],
})
export class AddTvSeriesComponent implements OnInit {
  form: FormGroup;
  name: string;
  userId: string;
  showImage: string;
  description: string;
  genre: string;
  rating: number;

  constructor(
    public dialogRef: MatDialogRef<AddTvSeriesComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AddTvSeriesComponentDialog,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.userId = this.data.userId;
    this.form = this.fb.group({
      name: [this.name, []],
      showImage: [this.showImage, []],
      description: [this.description, []],
      genre: [this.genre, []],
      rating: [this.rating, []]

      
    });
  }
  close() {
    this.dialogRef.close()
  }
  save() {
    console.log(this.form.value)
  }
}
