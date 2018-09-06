import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddCarComponent } from './add/add-car.component';
import { AllCarsComponent } from './all/all-cars.component';
import { CarDetailsComponent } from './details/car-details.component';

import { PrivateRoute } from '../core/private-route';

const routes: Routes = [
    { path: 'add', component: AddCarComponent, canActivate: [PrivateRoute] },
    { path: 'all', component: AllCarsComponent },
    { path: 'details/:id', component: CarDetailsComponent, canActivate: [PrivateRoute] }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class CarsRoutesModule { }