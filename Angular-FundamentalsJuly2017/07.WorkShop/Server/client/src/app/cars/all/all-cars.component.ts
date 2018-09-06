import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { CarsService } from '../../core/services/cars/cars.service';

@Component({
    selector: 'all-cars',
    templateUrl: './all-cars.component.html'
})
export class AllCarsComponent {
    page: number = 1;
    searchText: string = '';
    cars: Array<object>;

    constructor(
        private carService: CarsService,
        private router: Router,
        private route: ActivatedRoute) {
        this.route.queryParams
            .subscribe(params => {
                this.page = +params['page'] || 1;
                this.searchText = params['search'];
            });

        this.carService.allCars(this.page, this.searchText)
            .subscribe(res => {
                this.cars = res;
            });
    }

    prevPage(): void {
        if (this.page === 1) {
            return;
        }

        const url = this.getUrl(this.page - 1);
        this.carService.allCars(this.page - 1)
            .subscribe(res => {
                this.cars = res;
                this.router.navigateByUrl(url);
            });
    }

    nextPage(): void {
        if (this.cars.length === 0 || this.cars.length < 10) {
            return;
        }

        const url = this.getUrl(this.page + 1);
        this.carService.allCars(this.page + 1)
            .subscribe(res => {
                this.cars = res;
                this.router.navigateByUrl(url);
            });
    }

    search(): void {
        this.carService.allCars(this.page, this.searchText)
            .subscribe(res => {
                this.cars = res;
                this.router.navigateByUrl(`cars/all?search=${this.searchText}`);
            });
    }

    private getUrl(page) {
        let url = `cars/all?page=${page}`;
        if (this.searchText) {
            url += `&search=${this.searchText}`;
        }

        return url;
    }
}