import { Component, OnInit, Input } from '@angular/core';
import { Room } from '../room';

@Component({
  selector: 'app-west-challenge',
  templateUrl: './west-challenge.component.html',
  styleUrls: ['./west-challenge.component.css']
})
export class WestChallengeComponent implements OnInit {
  @Input() room: Room;

  constructor() { }

  ngOnInit() {
  }

  get annoyanceOffset(): string {
    return (this.room.annoyanceFactor / 100.0).toFixed(2) + 'em';
  }

  get choppedContentTextOffset0(): string {
    return this.choppedContextText(0);
  }

  get choppedContentTextOffset1(): string {
    return this.choppedContextText(1);
  }

  get choppedContentTextOffset2(): string {
    return this.choppedContextText(2);
  }

  get choppedContentTextOffset3(): string {
    return this.choppedContextText(3);
  }

  choppedContextText(offset: number): string {
    let outStr: string = '';
    let idx: number = 0;
    for (let thisChar of this.room.contentText) {
      if (idx++ % 4 == offset || thisChar==' ')
        outStr += thisChar;
      else
        outStr += '_';
    }
    return outStr;
  }
}
