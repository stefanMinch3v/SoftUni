import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common';
import { CarsRoutingModule } from './car-routing.module';

import { CarComponent } from './all-cars/car.component';
import { CarDetailsComponent } from './car-details/car-id.component';
import { CarService } from './services/car.service';

@NgModule({
    imports: [CommonModule, CarsRoutingModule],
    declarations: [CarComponent, CarDetailsComponent],
    providers: [CarService],
    //exports: [CarComponent, CarDetailsComponent]
})
export class CarsModule { }