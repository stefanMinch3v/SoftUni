import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CarComponent } from './all-cars/car.component';
import { CarDetailsComponent } from './car-details/car-id.component';

// Lazy loading /cars/...
const carRoutes: Routes = [
  { path: 'all', component: CarComponent },
  { path: ':id', component: CarDetailsComponent },
];

@NgModule({
  imports: [RouterModule.forChild(carRoutes)],
  exports: [RouterModule]
})
export class CarsRoutingModule { }