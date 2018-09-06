import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { UsersRoutesModule } from './routes.module';

import { usersComponents } from '.';

import { UsersService } from '../core/services/users/users.service';

@NgModule({
    imports: [CommonModule, UsersRoutesModule, FormsModule, HttpClientModule],
    declarations: [...usersComponents],
    providers: [UsersService]
})
export class UsersModule { }