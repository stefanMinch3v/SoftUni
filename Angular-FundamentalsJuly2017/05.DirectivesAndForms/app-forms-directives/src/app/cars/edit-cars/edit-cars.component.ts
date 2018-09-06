import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Car } from '../models/car.model';

import { CarService } from '../services/cars.service';

@Component({
    selector: 'edit-cars-form',
    templateUrl: './edit-cars.component.html'
})
export class EditCarFormComponent {
    private car: Car;
    private engines = [90, 101, 115, 191, 250, 500];

    constructor(
        private carService: CarService, 
        private route: ActivatedRoute) {
        const carId = parseInt(this.route.snapshot.paramMap.get('id'));
        this.car = this.carService.getCarById(carId);
    }

    public editCar(): void {
        this.carService.editCar(this.car);
        console.log(this.car);
    }
}