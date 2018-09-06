import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutesModule } from './app.routes.module';

import { UsersModule } from './users/users.module';
import { CoreModule } from './core/core.module';
import { CarsModule } from './cars/cars.module';
import { StatsModule } from './stats/stats.module';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutesModule,
    UsersModule,
    CarsModule,
    CoreModule,
    StatsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
