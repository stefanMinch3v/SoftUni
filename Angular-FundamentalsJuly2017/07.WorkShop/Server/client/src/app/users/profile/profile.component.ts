import { Component } from '@angular/core';

import { UsersService } from '../../core/services/users/users.service';
import { CarsService } from '../../core/services/cars/cars.service';

@Component({
    selector: 'profile',
    templateUrl: './profile.component.html'
})
export class ProfileComponent {
    userCars: Array<object> = [];

    constructor(private userService: UsersService, private carsService: CarsService) {
        this.userService.profile()
            .subscribe(res => this.userCars = res);
    }

    delete(carId) {
        this.carsService.deleteCar(carId)
            .subscribe(res => {
                if (res.success) {
                    this.userService.profile()
                        .subscribe(res => this.userCars = res);
                } else {
                    console.log(res)
                }
            });
    }
}