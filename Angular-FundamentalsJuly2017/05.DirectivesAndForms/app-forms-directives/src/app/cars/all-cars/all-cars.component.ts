import { Component } from '@angular/core';

import { CarService } from '../services/cars.service';
import { Car } from '../models/car.model';

@Component({
    selector: 'all-cars',
    templateUrl: './all-cars.component.html'
})
export class AllCarsComponent {
    private cars: Array<Car>;

    constructor (private readonly carService: CarService) {
        this.getAll();
    }

    public getAll(): void {
        this.cars = this.carService.getAllCollectionCars();
        this.cars.sort((a, b) => this.compare(a, b));
    }

    private compare(a,b) {
        if (a.id < b.id)
          return -1;
        if (a.id > b.id)
          return 1;
        return 0;
    }
}