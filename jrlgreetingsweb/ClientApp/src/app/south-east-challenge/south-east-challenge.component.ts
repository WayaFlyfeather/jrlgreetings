import { Component, OnInit, Input } from '@angular/core';
import { Room } from '../room';

@Component({
  selector: 'app-south-east-challenge',
  templateUrl: './south-east-challenge.component.html',
  styleUrls: ['./south-east-challenge.component.css']
})
export class SouthEastChallengeComponent implements OnInit {
  @Input() room: Room;

  constructor() { }

  ngOnInit() {
  }

  get scrambledContentText(): string {
    let scrambledText: string = '';

    if (this.room.annoyanceFactor < .3)
      return this.room.contentText;

    let segLength: number = Math.floor(this.room.contentText.length / (this.room.annoyanceFactor + 1.0));
    if (segLength < 2)
      segLength = 2;

//    let segments: string[];
    let idx: number = 0;

    while (idx < this.room.contentText.length) {
      if (segLength + idx > this.room.contentText.length)
        segLength = this.room.contentText.length - idx;

      scrambledText = this.room.contentText.substr(idx, segLength) + scrambledText;
      idx += segLength;
    }

    return scrambledText;

  }
}
