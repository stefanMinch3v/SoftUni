import { Component } from '@angular/core';

import { StatsService } from '../core/services/stats.service';

import { StatsModel } from './stats.model';

@Component({
    selector: 'stats',
    templateUrl: './stats.component.html'
})
export class StatsComponent {
    stats: StatsModel = new StatsModel();

    constructor(private statsService: StatsService) { 
        this.statsService.get()
            .subscribe(res => {
                this.stats.cars = res.cars;
                this.stats.users = res.users;
            });
    }
}