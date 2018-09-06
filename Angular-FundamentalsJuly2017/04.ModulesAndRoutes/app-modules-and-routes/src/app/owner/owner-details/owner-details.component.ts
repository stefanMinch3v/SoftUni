import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { OwnerService } from '../services/owner.service';
import { Owner } from '../../models/owner.model';

@Component({
    selector: 'owner-details',
    templateUrl: './owner-details.component.html'
})
export class OwnerDetailsComponent {
    private owner: Owner;
    constructor(
        private readonly ownerService: OwnerService,
        private readonly route: ActivatedRoute) {
        const paramId = parseInt(this.route.snapshot.paramMap.get('id'));
        this.getById(paramId);
    }

    public getById(id: number): void {
        this.owner = this.ownerService.getById(id);
    }
}