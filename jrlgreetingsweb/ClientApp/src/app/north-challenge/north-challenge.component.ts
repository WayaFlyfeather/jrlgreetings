import { Component, OnInit, Input } from '@angular/core';
import { Room } from '../room';

@Component({
  selector: 'app-north-challenge',
  templateUrl: './north-challenge.component.html',
  styleUrls: ['./north-challenge.component.css']
})
export class NorthChallengeComponent implements OnInit {
  @Input() room: Room;

  constructor() { }

  ngOnInit() {
  }

  get rotationDegrees(): string {
    return this.room.annoyanceFactor.toFixed(2)+'deg';
  }
}
