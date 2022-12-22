import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ErrorHandlerService } from 'src/shared/services/error-handler.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { FlexLayoutModule } from '@angular/flex-layout';
import { AddTvSeriesComponent } from './home/add-tv-series/add-tv-series.component';
import { TvSeriesCardComponent } from './home/tv-series-card/tv-series-card.component';
import { TvRatingStarComponent } from './home/tv-rating-star/tv-rating-star.component';
import { SpinnerComponent } from './home/spinner/spinner.component';
import { LoadingInterceptor } from 'src/shared/services/loading.interceptor';
import { MatSelectModule } from '@angular/material/select';
import { AddNetworkDialogComponent } from './home/add-network-dialog/add-network-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AddTvSeriesComponent,
    TvSeriesCardComponent,
    TvRatingStarComponent,
    SpinnerComponent,
    AddNetworkDialogComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    FlexLayoutModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      {
        path: 'authentication',
        loadChildren: () =>
          import('./authentication/authentication.module').then(
            (m) => m.AuthenticationModule
          ),
      },
    ]),
    BrowserAnimationsModule,
    MatTableModule,
    MatDialogModule,
    MatButtonModule,
    MatInputModule,
    MatIconModule,
    MatFormFieldModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MatSelectModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlerService,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoadingInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
