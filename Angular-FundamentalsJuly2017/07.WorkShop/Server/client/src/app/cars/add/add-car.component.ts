import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { CarsService } from '../../core/services/cars/cars.service';

import { AddCarModel } from '../../core/models/cars/add-car.model';

@Component({
    selector: 'add-car',
    templateUrl: './add-car.component.html'
})
export class AddCarComponent { 
    car: AddCarModel;

    constructor(private carsService: CarsService, private router: Router) {
        this.car = new AddCarModel();
    }

    addCar(): void {
        this.carsService.addCar(this.car)
            .subscribe(res => {
                if(res.success) {
                    // res.message, res.car
                    const carId = res.car.id;
                    this.router.navigateByUrl(`cars/details/${carId}`);
                } else {
                    console.log(res);
                }
            });
    }
}