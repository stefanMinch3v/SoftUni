import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { CarsService } from '../../core/services/cars/cars.service';

import { CarDetailsModel } from '../../core/models/cars/car-details.model';
import { CarReviewModel } from '../review/car-review.model';

@Component({
    selector: 'car-details',
    templateUrl: './car-details.component.html'
})
export class CarDetailsComponent {
    car: CarDetailsModel;
    id: string;
    carReview: CarReviewModel;
    reviews: Array<object> = [];

    constructor(
            private carsService: CarsService,
            private route: ActivatedRoute) {
        this.carReview = new CarReviewModel(5);

        this.id = this.route.snapshot.paramMap.get('id');
        this.carsService.getCar(this.id)
            .subscribe(res => this.car = res);

        this.carsService.allReviews(this.id)
            .subscribe(res => {
                if (!res.success) {
                    this.reviews = res;
                } else {
                    console.log(res);
                }
            });
    }

    like(): void {
        this.carsService.likeCar(this.car.id)
            .subscribe(res => {
                if (res.success) {
                    this.car.likes++;
                } else {
                    console.log(res);
                }            
            });
    }

    submitReview(): void {
        this.carsService.submitReview(this.car.id, this.carReview)
            .subscribe(res => {
                if (res.success) {
                    this.carReview.comment = '';
                    this.carReview.rating = 5;
                    this.carsService.allReviews(this.id)
                        .subscribe(res => {
                            this.reviews = res;
                        });
                } else {
                    console.log(res);
                }
            });
    }
}