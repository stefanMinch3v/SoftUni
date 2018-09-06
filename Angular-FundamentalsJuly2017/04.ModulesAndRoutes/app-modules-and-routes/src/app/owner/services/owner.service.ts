import { Injectable } from '@angular/core';

import { OwnerCarsData } from '../../data/data';
import { Owner } from '../../models/owner.model';

@Injectable()
export class OwnerService {
    private ownersOnly: Array<Owner>;

    getOwnersAndCars(): Array<Owner> {
        return new OwnerCarsData().getData();
    }

    getOwnersOnly(): Array<Owner> {
        this.ownersOnly = [];
        let data = new OwnerCarsData().getData();
        for (const line of data) {
            let owner = new Owner(line.id, line.firstName, line.lastName, line.age, null);
            this.ownersOnly.push(owner);
        }

        return this.ownersOnly;
    }

    getById(id: number): Owner {
        return new OwnerCarsData().getData().find(o => o.id === id);
    }
}