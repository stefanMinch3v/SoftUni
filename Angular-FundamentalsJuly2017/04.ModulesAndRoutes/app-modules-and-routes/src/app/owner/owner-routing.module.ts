import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { OwnerComponent } from './all-owners/owner.component';
import { OwnerDetailsComponent } from './owner-details/owner-details.component';

const ownerRoutes: Routes = [
    { path: 'all', component: OwnerComponent },
    { path: ':id', component: OwnerDetailsComponent }
];

@NgModule({
    imports: [RouterModule.forChild(ownerRoutes)],
    exports: [RouterModule]
})
export class OwnersRoutingModule { }