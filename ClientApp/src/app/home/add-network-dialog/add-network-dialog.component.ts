import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NetworkService } from 'src/shared/services/network.service';
import { TvApiService } from 'src/shared/services/tv-api.service';
import { NetworkLogo } from 'src/_interfaces/tv-series/network-logos.model';

export class AddNetworkDialog {
  network: NetworkLogo;
  userId: string;
}

@Component({
  selector: 'app-add-network-dialog',
  templateUrl: './add-network-dialog.component.html',
  styleUrls: ['./add-network-dialog.component.css'],
})
export class AddNetworkDialogComponent implements OnInit {
  form: FormGroup;
  networkName: string;
  userId: string;
  networkLogoUrl: string;
  isNew: boolean = true;

  constructor(
    public dialogRef: MatDialogRef<AddNetworkDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AddNetworkDialog,
    private fb: FormBuilder,
    private networkService: NetworkService,
    private tvService: TvApiService
  ) {}

  ngOnInit(): void {
    this.userId = this.data.userId;

    this.isNew = this.data?.network === null;
    this.form = this.fb.group({
      networkName: [this.networkName, []],
      networkLogoUrl: [this.networkLogoUrl, []],
    });
    if (!this.isNew && this.data?.network?.id) {
      this.form.setValue({
        networkName: this.data.network.networkName,
        networkLogoUrl: this.data.network.logoUrl,
      });
    }
  }

  close() {
    this.dialogRef.close();
  }

  save() {
    const network = this.form.value as NetworkLogo;
    network.userId = this.userId;
    if (this.isNew) {
      this.networkService.createNetworkLogo(network).subscribe((res) => {
        this.dialogRef.close();
      });
    } else {
      this.networkService.editNetworkLogo(network).subscribe((res) => {
        this.dialogRef.close();
      });
    }
  }

  handleUpload(file: any) {
    if (file[0]) {
      const fileName = file[0].name;
      let formData = new FormData();
      formData.append('image', file[0], fileName);
      this.tvService
        .uploadImageGetUrl(formData, this.userId)
        .subscribe((res) => {
          this.form.patchValue({ networkLogoUrl: res });
        });
    }
  }
}
