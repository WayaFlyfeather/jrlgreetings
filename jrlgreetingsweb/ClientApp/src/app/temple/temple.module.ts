import { NgModule } from '@angular/core';

import { TempleRoutingModule } from './temple-routing.module';
import { RoomComponent } from './room/room.component';
import { NorthWestChallengeComponent } from './north-west-challenge/north-west-challenge.component';
import { NorthChallengeComponent } from './north-challenge/north-challenge.component';
import { NorthEastChallengeComponent } from './north-east-challenge/north-east-challenge.component';
import { WestChallengeComponent } from './west-challenge/west-challenge.component';
import { SouthWestChallengeComponent } from './south-west-challenge/south-west-challenge.component';
import { SouthChallengeComponent } from './south-challenge/south-challenge.component';
import { SouthEastChallengeComponent } from './south-east-challenge/south-east-challenge.component';
import { EastChallengeComponent } from './east-challenge/east-challenge.component';
import { CentralChallengeComponent } from './central-challenge/central-challenge.component';
import { ExceptionalChallengeComponent } from './exceptional-challenge/exceptional-challenge.component';
import { TempleEntranceComponent } from './temple-entrance/temple-entrance.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSliderModule } from '@angular/material/slider';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
    declarations: [
        RoomComponent,
        NorthWestChallengeComponent,
        NorthChallengeComponent,
        NorthEastChallengeComponent,
        WestChallengeComponent,
        SouthWestChallengeComponent,
        SouthChallengeComponent,
        SouthEastChallengeComponent,
        EastChallengeComponent,
        CentralChallengeComponent,
        ExceptionalChallengeComponent,
        TempleEntranceComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        MatFormFieldModule,
        MatSliderModule,
        MatSelectModule,
        TempleRoutingModule
    ]
})
export class TempleModule {}
