import { Component } from '@angular/core';
import { CreateCar } from '../models/create-car.model';

import { CarService } from '../services/cars.service';

@Component({
    selector: 'create-car-form',
    templateUrl: './create-car.component.html'
})
export class CreateCarFormComponent {
    engines = [90, 101, 115, 191, 250, 500];
    car: CreateCar;

    constructor(private carService: CarService) {
        this.clearCar();
    }

    clearCar() {
        this.car = new CreateCar('', '', '', this.engines[4]);
    }

    submitCar() {
        // add validations
        console.log(this.car);
        this.carService.createCar(this.car);
    }
}
