import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { CarService } from '../services/car.service';
import { Car } from '../../models/car.model';

@Component({
    selector: 'car-id',
    templateUrl: './car-id.component.html'
})
export class CarDetailsComponent {
    private car: Car;
    constructor(
        private readonly carService: CarService, 
        private readonly route: ActivatedRoute) { 
            const paramId = parseInt(this.route.snapshot.paramMap.get('id'));
            this.getById(paramId);
        }

    public getById(id: number): void {
        this.car = this.carService.getCarById(id);
    }
}