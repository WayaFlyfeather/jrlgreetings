import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatSliderModule } from '@angular/material/slider';

import { RoomsService } from './rooms.service';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { RoomComponent } from './room/room.component';
import { NorthWestChallengeComponent } from './north-west-challenge/north-west-challenge.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    RoomComponent,
    NorthWestChallengeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'temple/northwest', component: RoomComponent, data: { roomId: 0 } },
      { path: 'temple/north', component: RoomComponent, data: { roomId: 1 } },
      { path: 'temple/northeast', component: RoomComponent, data: { roomId: 2 } },
      { path: 'temple/west', component: RoomComponent, data: { roomId: 3 } },
      { path: 'temple/central', component: RoomComponent, data: { roomId: 4 } },
      { path: 'temple/east', component: RoomComponent, data: { roomId: 5 } },
      { path: 'temple/southwest', component: RoomComponent, data: { roomId: 6 } },
      { path: 'temple/south', component: RoomComponent, data: { roomId: 7 } },
      { path: 'temple/southeast', component: RoomComponent, data: { roomId: 8 } },
      { path: 'temple/exceptional', component: RoomComponent, data: { roomId: 9 } },
    ]),
    MatSliderModule,
  ],
  providers: [RoomsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
