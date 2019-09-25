import { Component, OnInit, Input } from '@angular/core';
import { Room } from '../../room';

@Component({
  selector: 'app-south-challenge',
  templateUrl: './south-challenge.component.html',
  styleUrls: ['./south-challenge.component.css']
})
export class SouthChallengeComponent implements OnInit {
  @Input() room: Room;

  constructor() { }

  ngOnInit() {
  }

  get veil7visible(): boolean {
    return this.room.annoyanceFactor > 5.0 ? true : false;
  }
  get veil6visible(): boolean {
    return this.room.annoyanceFactor > 19.0 ? true : false;
  }
  get veil5visible(): boolean {
    return this.room.annoyanceFactor > 33.0 ? true : false;
  }
  get veil4visible(): boolean {
    return this.room.annoyanceFactor > 47.0 ? true : false;
  }
  get veil3visible(): boolean {
    return this.room.annoyanceFactor > 61.0 ? true : false;
  }
  get veil2visible(): boolean {
    return this.room.annoyanceFactor > 75.0 ? true : false;
  }
  get veil1visible(): boolean {
    return this.room.annoyanceFactor > 89.0 ? true : false;
  }
}
