import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable()
export class StatsService {
    constructor(private httpService: HttpService) { }

    get() {
        return this.httpService.getRequest('stats');
    }
}