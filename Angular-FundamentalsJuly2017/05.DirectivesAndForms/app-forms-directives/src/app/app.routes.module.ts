import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CarsModule } from './cars/cars.module';

import { HomeComponent } from './home/home.component';

const routes: Routes = [
    {
        path: '',
        component: HomeComponent
    },
    { 
        path: 'cars', 
        loadChildren: () => CarsModule // lazy loading /cars/...
    },
    { 
        path: '**',
        redirectTo: '' 
    }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutesModule { }