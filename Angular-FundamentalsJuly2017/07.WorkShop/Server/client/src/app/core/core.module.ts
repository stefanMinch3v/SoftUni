import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';

import { AuthService } from './services/auth.service';
import { NavbarComponent } from './navbar.component';
import { PrivateRoute } from './private-route';

@NgModule({
    imports: [CommonModule, RouterModule, HttpModule],
    declarations: [NavbarComponent],
    exports: [NavbarComponent],
    providers: [AuthService, PrivateRoute]
})
export class CoreModule { }