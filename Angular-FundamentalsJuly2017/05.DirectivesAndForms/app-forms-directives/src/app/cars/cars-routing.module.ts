import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AllCarsComponent } from './all-cars/all-cars.component';
import { CreateCarFormComponent } from './create-cars/create-car.component';
import { EditCarFormComponent } from './edit-cars/edit-cars.component';

const carRoutes: Routes = [
    { path: 'all', component: AllCarsComponent },
    { path: 'create', component: CreateCarFormComponent },
    { path: 'edit/:id', component: EditCarFormComponent }
];

@NgModule({
    imports: [RouterModule.forChild(carRoutes)],
    exports: [RouterModule]
})
export class CarsRoutingModule { }