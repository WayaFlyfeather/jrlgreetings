import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { MatSliderModule } from '@angular/material/slider';

import { RoomsService } from '../rooms.service';
import { NorthWestChallengeComponent } from '../north-west-challenge/north-west-challenge.component';
import { Room } from '../room';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css'],
})
export class RoomComponent implements OnInit {  
  protected room: Room=null;
  protected roomId: number;
  constructor(
    protected roomsService: RoomsService,
    protected router: Router,
    protected route: ActivatedRoute) {
    this.roomId = route.snapshot.data.roomId;
    console.log('RoomId: ' + this.roomId);
    //route.params.subscribe(value => {
    //  this.room = null;
    //  this.getRoom();
    //})
  }

  ngOnInit() {
    this.getRoom();
  }

  protected updateAnnoyanceFactor(event: any) {
    this.room.annoyanceFactor = event.value;
  }

  getRoom(): void {
    //this.roomId = +this.route.snapshot.paramMap.get('roomId');
    this.roomsService.getRoom(this.roomId)
      .subscribe(room => {
        this.room = room;
      });
  }

  get canGoNorth() :boolean {
    if (this.roomId < 3 || this.roomId == 9)
      return false;
    else
      return true;
  }

  get canGoWest(): boolean {
    if (this.roomId % 3 == 0 || this.roomId == 9)
      return false;
    else
      return true;
  }

  get canGoSouth(): boolean {
    if (this.roomId > 5 || this.roomId == 9)
      return false;
    else
      return true;
  }

  get canGoEast(): boolean {
    if (this.roomId % 3 == 2 || this.roomId == 9)
      return false;
    else
      return true;
  }

  goNorth(): void {
    if (this.canGoNorth)
      this.router.navigate(['temple', this.roomId - 3]);
  }

  goWest(): void {
    if (this.canGoWest)
      this.router.navigate(['temple', this.roomId - 1]);
  }

  goSouth(): void {
    if (this.canGoSouth)
      this.router.navigate(['temple', this.roomId + 3]);
  }

  goEast(): void {
    if (this.canGoEast)
      this.router.navigate(['temple', this.roomId + 1]);
  }
}
