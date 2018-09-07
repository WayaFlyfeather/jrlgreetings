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
    let colorPart: string = (128 - this.annoyanceOffset()).toString(16);
    return '#' + colorPart + colorPart + colorPart;
  }

  get annoyanceBackgroundColor(): string {
    let colorPart: string = (127 + this.annoyanceOffset()).toString(16);
    return '#' + colorPart + colorPart + colorPart;
  }

  annoyanceOffset(): number {
    return Math.pow(100 - this.room.annoyanceFactor, 2) * 0.0128;
  }
}
