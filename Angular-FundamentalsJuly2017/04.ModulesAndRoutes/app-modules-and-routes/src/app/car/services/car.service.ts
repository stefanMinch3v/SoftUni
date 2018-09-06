import { Injectable } from '@angular/core';

import { OwnerCarsData } from '../../data/data';
import { Car } from '../../models/car.model';

@Injectable()
export class CarService {
    private cars: Array<Car> = [];

    getAllCars(): Array<Car> {
        let data = new OwnerCarsData().getData();
        for (const line of data) {
            for (const carLine of line.cars) {
                this.cars.push(carLine);
            }
        }

        return this.cars;
    }

    getCarById(id: number): Car {
        let data = new OwnerCarsData().getData();
        for (const line of data) {
            let car = line.cars.find(c => c.id === id);
            if (car) {
                return car;
            }
        }

        return new Car(0, null, null, null, null, null);
    }
}