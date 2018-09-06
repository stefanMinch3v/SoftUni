import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';

import { AuthService } from './services/auth.service';

@Injectable()
export class PrivateRoute implements CanActivate {
    constructor(private authService: AuthService) { }

    canActivate(): boolean {
        // redirect to login if not authenticated or whatever
        return this.authService.isUserAuthenticated();
    }
}