import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { MatSliderModule } from '@angular/material/slider';

import { RoomsService } from '../rooms.service';
import { NorthWestChallengeComponent } from '../north-west-challenge/north-west-challenge.component';
import { Room } from '../room';
import { Temple } from '../temple';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css'],
})
export class RoomComponent implements OnInit {  
  protected room: Room = null;
  protected temple: Temple;
  protected roomId: number;
  constructor(
    protected roomsService: RoomsService,
    protected router: Router,
    protected route: ActivatedRoute) {
    this.roomId = route.snapshot.data.roomId;
  }

  ngOnInit() {
    this.getRoom();
    this.getTemple();
  }

  protected updateAnnoyanceFactor(event: any) {
    this.room.annoyanceFactor = event.value;
    if (this.room.annoyanceFactor == 0.0)
      this.room.completed = true;
    this.roomsService.updateRoom(this.room);
  }

  getRoom(): void {
    this.roomsService.getRoom(this.roomId)
      .subscribe(room => {
        this.room = room;
      });
  }

  getTemple(): void {
    this.roomsService.getTemple()
      .subscribe(temple => {
        this.temple = temple;
      });
  }

  static roomNameFromRoomId(roomId: number): string {
    switch (roomId) {
      case 0: return 'northwest';
      case 1: return 'north';
      case 2: return 'northeast';
      case 3: return 'west';
      case 4: return 'central';
      case 5: return 'east';
      case 6: return 'southwest';
      case 7: return 'south';
      case 8: return 'southeast';
      case 9: return 'exceptional';
      default: return 'northwest';
    }
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
      this.router.navigate(['temple', RoomComponent.roomNameFromRoomId(this.roomId - 3)]);
  }

  goWest(): void {
    if (this.canGoWest)
      this.router.navigate(['temple', RoomComponent.roomNameFromRoomId(this.roomId - 1)]);
  }

  goSouth(): void {
    if (this.canGoSouth)
      this.router.navigate(['temple', RoomComponent.roomNameFromRoomId(this.roomId + 3)]);
  }

  goEast(): void {
    if (this.canGoEast)
      this.router.navigate(['temple', RoomComponent.roomNameFromRoomId(this.roomId + 1)]);
  }
}
