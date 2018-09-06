import { Component } from '@angular/core';

import { CarService } from '../services/car.service';
import { Car } from '../../models/car.model';

@Component({
    selector: 'all-cars',
    templateUrl: './car.component.html'
})
export class CarComponent {
    private cars: Array<Car>;
    private showCarsBtn: boolean;

    constructor(private readonly carService: CarService) { 
        this.cars = [];
        this.showCarsBtn = true;
    }

    public getAll(): void {
        this.showCarsBtn = false;
        this.cars = this.carService.getAllCars();
    }
}