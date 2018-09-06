import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { CarsModule } from './car/car.module';
import { OwnersModule } from './owner/owner.module';

import { AppRoutesModule } from './routes.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutesModule,
    CarsModule,
    OwnersModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
