import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';
// import { currentUser } from '../users/currentUser';

@Component({
    selector: 'navbar',
    templateUrl: './navbar.component.html'
})
export class NavbarComponent { 
    username: string;
    loggedIn: boolean = false;

    constructor(private authService: AuthService) {
        if (this.authService.isUserAuthenticated()) {
            this.loggedIn = true;
            this.username = this.authService.getUser();
            // two ways of doing this one is with the auth service which stores data in the browser
            // the other way is with currentUser object which stores data on the app not in the browser
            // this menu must be in the main app component in order to get the proper menu without refreshing the page
        }
    }
}