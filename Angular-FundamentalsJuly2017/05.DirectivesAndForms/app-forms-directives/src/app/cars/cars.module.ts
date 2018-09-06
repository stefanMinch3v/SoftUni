import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { CarsRoutingModule } from './cars-routing.module';

import { carsComponents } from '.';

import { CarService } from './services/cars.service';

import { CarImageDirective } from './cars-image.directive';

import { CarsEnginePipe } from "./cars-engine.pipe";

@NgModule({
    imports: [CommonModule, CarsRoutingModule, FormsModule],
    declarations: [...carsComponents, CarImageDirective, CarsEnginePipe],
    providers: [CarService]
})
export class CarsModule { }
