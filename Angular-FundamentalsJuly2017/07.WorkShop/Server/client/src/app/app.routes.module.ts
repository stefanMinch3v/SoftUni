import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { UsersModule } from './users/users.module';
import { CarsModule } from './cars/cars.module';

import { StatsComponent } from './stats/stats.component';

const routes: Routes = [
    {
        path: '',
        component: StatsComponent
    },
    { 
        path: 'users', 
        loadChildren: () => UsersModule // lazy loading /cars/...
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