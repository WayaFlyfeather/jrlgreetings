import { Component, OnInit, Input } from '@angular/core';
import { Room } from '../room';

@Component({
  selector: 'app-south-west-challenge',
  templateUrl: './south-west-challenge.component.html',
  styleUrls: ['./south-west-challenge.component.css']
})
export class SouthWestChallengeComponent implements OnInit {
  @Input() room: Room;

  constructor() { }

  ngOnInit() {
  }

  get annoyanceColor(): string {
    //move towards foreground color, which depends on whether room is completed or not
    let targetR: number = this.room.completed ? 128 : 16; // 80 or 10
    let targetG: number = 16;                             // 10
    let targetB: number = 16;                             // 10
    let colorR: string = (128 - this.annoyanceOffset(128-targetR)).toString(16);
    let colorG: string = (128 - this.annoyanceOffset(128-targetG)).toString(16);
    let colorB: string = (128 - this.annoyanceOffset(128-targetB)).toString(16);
    return '#' + colorR + colorG + colorB;
  }

  get annoyanceBackgroundColor(): string {
    //move towards background color, which depends on whether room is completed or not
    let targetR: number = this.room.completed ? 232 : 244; // e8 or f4
    let targetG: number = this.room.completed ? 232 : 244; // e8 or f4
    let targetB: number = this.room.completed ? 255 : 244; // ff or f4
    let colorR: string = (128 + this.annoyanceOffset(targetR-128)).toString(16);
    let colorG: string = (128 + this.annoyanceOffset(targetG-128)).toString(16);
    let colorB: string = (128 + this.annoyanceOffset(targetB-128)).toString(16);
    return '#' + colorR + colorG + colorB;
  }

  annoyanceOffset(target: number): number {
    return Math.floor(Math.pow(100 - this.room.annoyanceFactor, 2) * target / 10000);
  }
}
