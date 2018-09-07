import { Component, OnInit, Input } from '@angular/core';
import { Room } from '../room';


@Component({
  selector: 'app-north-west-challenge',
  templateUrl: './north-west-challenge.component.html',
  styleUrls: ['./north-west-challenge.component.css']
})
export class NorthWestChallengeComponent implements OnInit {
  @Input() room: Room;
  constructor() { }

  ngOnInit() {
  }

  get opacityStyle(): string {
    let opacityAnnoyance: number = 1.0 - (this.room.annoyanceFactor / 100.0);
    return opacityAnnoyance.toFixed(2);
  }
}
