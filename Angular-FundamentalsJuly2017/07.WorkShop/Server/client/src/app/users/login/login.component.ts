import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { UsersService } from '../../core/services/users/users.service';
import { AuthService } from '../../core/services/auth.service';

import { LoginUser } from "../../core/models/users/login-user.model";
import { NavbarComponent } from '../../core/navbar.component';

// import { currentUser } from '../currentUser';

@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})
export class LoginComponent {
    private user: LoginUser;

    constructor(
        private usersService: UsersService,
        private authService: AuthService,
        private router: Router) {
        this.user = new LoginUser();
    }

    public login() {
        this.usersService.login(this.user)
            .subscribe(res => {
                if (res.success) {
                    this.authService.authenticateUser(res.token);
                    this.authService.saveUser(res.user.name);

                    // currentUser.username = res.user.name;
                    // currentUser.loggedIn = true;

                    this.router.navigateByUrl('/');
                }
            });
    }
}