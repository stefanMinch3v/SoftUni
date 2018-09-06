import { Injectable } from '@angular/core';

import { OwnerCarsData } from '../../data/data';
import { Car } from '../models/car.model';
import { CreateCar } from '../models/create-car.model';

@Injectable()
export class CarService {
    private cars: Array<Car> = [];

    constructor() {
        this.getAllCars();
    }

    getAllCollectionCars() {
        return this.cars;
    }

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

    createCar(car: CreateCar): void {
        // add validations
        const carId = this.cars.length;
        const newCar = new Car(carId, car.make, car.model, car.imageUrl, car.engine, new Date(Date.now()));
        this.cars.push(newCar);
    }

    editCar(car: Car): void {
        // add validations
        const oldCar = this.cars.find(c => c.id === car.id);
        this.cars.splice(car.id - 1, 1);

        oldCar.make = car.make;
        oldCar.model = car.model;
        oldCar.engine = car.engine;
        oldCar.imageUrl = car.imageUrl;
        
        this.cars.push(oldCar);
    }
}