import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StatsComponent } from './stats.component';

import { StatsService } from '../core/services/stats.service';
import { HttpService } from '../core/services/http.service';

@NgModule({
    imports: [CommonModule],
    declarations: [StatsComponent],
    providers: [StatsService, HttpService]
})
export class StatsModule { }