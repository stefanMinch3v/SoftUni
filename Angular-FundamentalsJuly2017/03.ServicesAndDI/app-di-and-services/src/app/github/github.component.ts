import { Component } from '@angular/core';
import { GithubService } from '../service/github.service';

import { GithubProfile } from '../models/github-profile.model';

const username = 'stefanMinch3v';

@Component({
  selector: 'github',
  templateUrl: './github.component.html'
})
export class GithubComponent {
    profile: GithubProfile;
    repos?: number;
    followers?: number;

    constructor(private githubService: GithubService) {}

    public getProfile(): void {
        this.githubService.getProfile(username)
            .subscribe(data => {
                this.profile = this.mapDataToModel(data);
                console.log(this.profile);
            });
    }

    public getRepos(): void {
        this.githubService.getRepos(username)
            .subscribe(data => {
                this.repos = data.public_repos;
            })
    }

    public getFollowers(): void {
        this.githubService.getFollowers(username)
            .subscribe(data => {
                this.followers = data.followers;
            });
    }

    public mapDataToModel(obj: GithubProfile): GithubProfile {
        const { avatar_url, login, name, public_repos, followers, following }  = obj;
        return { avatar_url, login, name, public_repos, followers, following };
    }
}