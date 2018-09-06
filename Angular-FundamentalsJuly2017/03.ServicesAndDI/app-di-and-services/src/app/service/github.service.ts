import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { GithubProfile } from '../models/github-profile.model';
import { GithubRepos } from '../models/github-repos.model';
import { GithubFollowers } from '../models/github-followers.model';

const url = 'https://api.github.com/users/';

@Injectable({
    providedIn: 'root'
})
export class GithubService {
    constructor(private http: HttpClient) { }

    public getProfile(username: string): Observable<GithubProfile> {
        return this.http.get<GithubProfile>(url + username);
    }

    public getRepos(username: string): Observable<GithubRepos> {
        return this.http.get<GithubRepos>(url + username);
    }

    public getFollowers(username: string): Observable<GithubFollowers> {
        return this.http.get<GithubFollowers>(url + username);
    }
}