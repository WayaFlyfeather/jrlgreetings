import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { Room } from '../room';
import { RoomsService } from '../rooms.service';
import { TempleAudioService } from '../temple-audio.service';

@Component({
  selector: 'app-east-challenge',
  templateUrl: './east-challenge.component.html',
  styleUrls: ['./east-challenge.component.css']
})
export class EastChallengeComponent implements OnInit, OnDestroy {
  @Input() room: Room;
  interval: NodeJS.Timer = null;
  annoyanceRotationX: number = 0;

  constructor(
    private roomsService: RoomsService,
    private templeAudioService: TempleAudioService
  ) { }

  ngOnInit() {
    this.interval = setInterval(() => this.timerTick(), 25);
  }

  ngOnDestroy() {
    if (this.interval)
      clearInterval(this.interval);
  }

  timerTick(): void {
    if (this.room == null)
      return;

    if (this.room.annoyanceFactor < 20 && (this.annoyanceRotationX < 3.0 || this.annoyanceRotationX > 356.0)) {
      if (this.annoyanceRotationX != 0.0) {
        this.annoyanceRotationX = 0.0;
        this.room.annoyanceFactor = 0.0;
        this.templeAudioService.playClick();
        this.room.completed = true;
        this.roomsService.updateRoom(this.room);
      }
    }
    else
      this.annoyanceRotationX = (this.annoyanceRotationX + this.room.annoyanceFactor * .2) % 360;
  }
}
