import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatSliderModule } from '@angular/material/slider';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';

import { RoomsService } from './rooms.service';
import { TempleAudioService } from './temple-audio.service';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
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
import { AppRoutingModule } from './app-routing.module';
import { TempleComponent } from './temple/temple.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
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
    TempleEntranceComponent,
    TempleComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    MatFormFieldModule,
    MatSliderModule,
    MatSelectModule,
  ],
  providers: [RoomsService, TempleAudioService],
  bootstrap: [AppComponent]
})
export class AppModule { }
