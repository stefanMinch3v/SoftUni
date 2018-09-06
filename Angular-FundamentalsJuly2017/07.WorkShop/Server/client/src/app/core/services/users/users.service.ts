import {Injectable} from '@angular/core'
import { HttpService } from '../http.service'

@Injectable()
export class UsersService {
    constructor (private httpService: HttpService) { }

    login(user) {
        return this.httpService.postRequest('auth/login', user);
    }

    register(user) {
        return this.httpService.postRequest('auth/signup', user);
    }

    profile() {
        return this.httpService.getRequest('cars/mine', true);
    }
}