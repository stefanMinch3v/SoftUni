import { Component } from '@angular/core';

import { OwnerService } from '../services/owner.service';
import { Owner } from '../../models/owner.model';

@Component({
    selector: 'owners',
    templateUrl: './owner.component.html'
})
export class OwnerComponent {
    private owners: Array<Owner>;
    private showCarsBtn: boolean;
    constructor(private readonly ownerService: OwnerService) { 
        this.owners = [];
        this.getAll();
        this.showCarsBtn = true;
    }

    public getAll(): void {
        this.owners = this.ownerService.getOwnersOnly();
    }

    public getAllWithCars(): void {
        this.showCarsBtn = false;
        this.owners = this.ownerService.getOwnersAndCars();
    }
}