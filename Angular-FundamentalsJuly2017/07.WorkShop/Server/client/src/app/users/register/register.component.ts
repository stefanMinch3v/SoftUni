import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { RegisterUser } from '../../core/models/users/register-user.model';

import { UsersService } from '../../core/services/users/users.service';

@Component({
    selector: 'register',
    templateUrl: './register.component.html'
})
export class RegisterComponent {
    user: RegisterUser;

    constructor(
        private usersService: UsersService, private router: Router) {
        this.user = new RegisterUser();
    }

    public register() {
        this.usersService.register(this.user)
            .subscribe(res => {
                if(res.success) {
                    this.router.navigateByUrl('users/login');
                } else {
                    console.log(res.errors || res.message);
                }
            });
    }
}