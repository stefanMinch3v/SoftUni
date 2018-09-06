import { Injectable } from '@angular/core'
import { HttpService } from '../http.service'

import { CarReviewModel } from '../../../cars/review/car-review.model';

@Injectable()
export class CarsService {
    constructor(private httpService: HttpService) { }

    addCar(car) {
        return this.httpService.postRequest('cars/create', car, true);
    }

    allCars(page = 1, search = null) {
        let url = `cars/all?page=${page}`;
        if (search) {
            url += `&search=${search}`;
        }

        return this.httpService.getRequest(url);
    }

    getCar(id) {
        return this.httpService.getRequest(`cars/details/${id}`, true);
    }

    likeCar(id) {
        return this.httpService.postRequest(`cars/details/${id}/like`, null, true);
    }

    submitReview(carId, carReview: CarReviewModel) {
        return this.httpService.postRequest(`cars/details/${carId}/reviews/create`, carReview, true);
    }

    allReviews(carid) {
        return this.httpService.getRequest(`cars/details/${carid}/reviews`, true);
    }

    deleteCar(id) {
        return this.httpService.postRequest(`cars/delete/${id}`, null, true);
    }
}