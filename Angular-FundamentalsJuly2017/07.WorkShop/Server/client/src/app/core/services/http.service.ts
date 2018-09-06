import { Injectable } from "@angular/core";
import { Http, Headers, RequestOptions } from "@angular/http";

import { AuthService } from "./auth.service";
// import { HttpService } from "../core/http.service";

// import { RegisterUser } from "../../models/users/register-user.model";

// import { LoginUser } from "../../models/users/login-user.model";

import { map } from 'rxjs/operators'

const baseUrl = 'http://localhost:5000/';
const getMethod = 'get';
const postMethod = 'post';

@Injectable()
export class HttpService {
    constructor(private http: Http, private authService: AuthService) { }

    public getRequest(url, authenticated = false) {
        const requestOptions = this.prepareRequestOptions(getMethod, authenticated);

        return this.http.get(`${baseUrl}${url}`, requestOptions)
            .pipe(map(res => res.json()));
    }

    public postRequest(url, data, authenticated = false) {
        const requestOptions = this.prepareRequestOptions(postMethod, authenticated);

        return this.http.post(`${baseUrl}${url}`, data, requestOptions)
            .pipe(map(res => res.json()));
    }

    private prepareRequestOptions(method, authenticated) {
        const headers = new Headers();

        if (method !== getMethod) {
            headers.append('Content-Type', 'application/json');
        }

        if (authenticated) {
            const token = this.authService.getToken();
            headers.append('Authorization', `bearer ${token}`);
        }

        const requestOptions = new RequestOptions({
            headers: headers
        });

        return requestOptions;
    }
}