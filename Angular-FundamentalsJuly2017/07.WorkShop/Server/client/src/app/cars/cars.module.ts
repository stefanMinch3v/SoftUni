import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CarsRoutesModule } from './routes.module';

import { carsComponents } from '.';

import { CarsService } from '../core/services/cars/cars.service';

@NgModule({
    imports: [CommonModule, CarsRoutesModule, FormsModule, HttpClientModule],
    declarations: [...carsComponents],
    providers: [CarsService]
})
export class CarsModule { }