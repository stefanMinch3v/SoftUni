import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../../core/services/auth.service';

@Component({
    selector: 'logout',
    template: ''
})
export class LogoutComponent {
    constructor(private router: Router, private authService: AuthService) {
        this.authService.deauthenticateUser();
        this.authService.removeUser();

        this.router.navigateByUrl('/');
    }
}