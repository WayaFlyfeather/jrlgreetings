import { Component, OnInit, Input } from '@angular/core';
import { Room } from '../../room';
import { RoomsService } from '../../rooms.service';
import { RoomComponent } from '../room/room.component';
import { Router } from '@angular/router';
import { TempleAudioService } from '../../temple-audio.service';

@Component({
  selector: 'app-exceptional-challenge',
  templateUrl: './exceptional-challenge.component.html',
  styleUrls: ['./exceptional-challenge.component.css']
})
export class ExceptionalChallengeComponent implements OnInit {
  @Input() room: Room;

  private rooms: Room[] = null;
  
  constructor(private roomsService: RoomsService,
    private templeAudioService: TempleAudioService,
    private router: Router
  ) { }

  ngOnInit() {
    this.roomsService.getRooms()
      .subscribe(rooms => {
        this.rooms = rooms;
        this.room = rooms[9];
      });
  }

  canGoToRoom(roomNo: number): boolean {
    if (roomNo < (100.0 - this.room.annoyanceFactor) / 10)
      return true;

    return false;
  }

  goToRoom(roomNo: number): void {
    if (this.canGoToRoom(roomNo)) {
      this.templeAudioService.playThunder();
      setTimeout(() => this.router.navigate(['temple', RoomComponent.roomNameFromRoomId(roomNo)]), 500);
    }
  }
}
