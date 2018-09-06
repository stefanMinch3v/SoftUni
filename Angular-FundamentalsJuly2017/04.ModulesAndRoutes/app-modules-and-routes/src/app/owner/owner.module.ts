import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common';
import { OwnersRoutingModule } from './owner-routing.module';

import { OwnerComponent } from './all-owners/owner.component';
import { OwnerDetailsComponent } from './owner-details/owner-details.component';

import { OwnerService } from './services/owner.service';

@NgModule({
    imports: [CommonModule, OwnersRoutingModule],
    declarations: [OwnerComponent, OwnerDetailsComponent],
    providers: [OwnerService]
})
export class OwnersModule { }