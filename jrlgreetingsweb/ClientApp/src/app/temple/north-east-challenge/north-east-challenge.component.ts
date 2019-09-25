import { Component, OnInit, Input } from '@angular/core';
import { Room } from '../../room';

@Component({
  selector: 'app-north-east-challenge',
  templateUrl: './north-east-challenge.component.html',
  styleUrls: ['./north-east-challenge.component.css']
})
export class NorthEastChallengeComponent implements OnInit {
  @Input() room: Room;

  constructor() { }

  ngOnInit() {
  }

  get annoyingRoomContentText(): string {
    let outStr: string = '';
    let truncAnnoyance: number = Math.floor(this.room.annoyanceFactor);
    for (let oneChar of this.room.contentText) {
      if (oneChar == ' ' || oneChar == '\n')
        outStr += oneChar;
      else
        outStr += String.fromCharCode(oneChar.charCodeAt(0) ^ (truncAnnoyance * truncAnnoyance));
    }
    return outStr;
  }
}
