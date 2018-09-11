import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { RoomsService } from '../rooms.service';
import { TempleAudioService } from '../temple-audio.service';
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
    private templeAudioService: TempleAudioService,
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
    if (this.room.annoyanceFactor == 0.0) {
      this.templeAudioService.playClick();
      this.room.completed = true;
    }
    this.roomsService.updateRoom(this.room);
  }

  get roomTitle(): string {
    let name: string = this.room.roomNo == 9 ? 'The Exceptional Room' : 'Room Number ' + (this.room.roomNo + 1).toString();

    return name + ' (' + this.temple.notCompletedRoomsCount + ' to complete)';
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

  public static roomNameFromRoomId(roomId: number): string {
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
    if (this.canGoNorth) {
      this.goToRoom(this.roomId - 3);
    }
  }

  goWest(): void {
    if (this.canGoWest) {
      this.goToRoom(this.roomId - 1);
    }
  }

  goSouth(): void {
    if (this.canGoSouth) {
      this.goToRoom(this.roomId + 3);
    }
  }

  goEast(): void {
    if (this.canGoEast) {
      this.goToRoom(this.roomId + 1);
    }
  }

  goToRoom(roomNo: number): void {
    this.templeAudioService.playFootsteps();
    setTimeout(() => this.router.navigate(['temple', RoomComponent.roomNameFromRoomId(roomNo)]), 500);
  }

}
