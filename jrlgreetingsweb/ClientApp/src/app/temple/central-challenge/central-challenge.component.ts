import { Component, OnInit, Input } from '@angular/core';
import { Room } from '../../room';
import { RoomComponent } from '../room/room.component';
import { Router } from '@angular/router';
import { TempleAudioService } from '../../temple-audio.service';


@Component({
  selector: 'app-central-challenge',
  templateUrl: './central-challenge.component.html',
  styleUrls: ['./central-challenge.component.css']
})
export class CentralChallengeComponent implements OnInit {
  @Input() room: Room;

  number1: number = 10;
  number2: number = 10;
  operators: string[] = ['+', '-', '*', '/'];
  selectedOperator: string = '+';

  constructor(
    private router: Router,
    private templeAudioService: TempleAudioService
  ) { }

  ngOnInit() {
  }

  get numberMin(): number {
    let min: number = Math.floor(this.room.annoyanceFactor / 10.0);
    if (this.number1 < min)
      this.number1 = min;
    if (this.number2 < min)
      this.number2 = min;
    return min;
  }

  get numberMax(): number {
    let max: number = Math.floor(this.room.annoyanceFactor / 10.0) + 20;
    if (this.number1 > max)
      this.number1 = max;
    if (this.number2 > max)
      this.number2 = max;
    return Math.floor(this.room.annoyanceFactor / 10.0) + 20;
  }

  private timeGuard: Date = null;
  get calcResult(): number {
    try {
      if (this.selectedOperator == '+')
        return this.number1 + this.number2;
      else if (this.selectedOperator == '-')
        return this.number1 - this.number2;
      if (this.selectedOperator == '*')
        return this.number1 * this.number2;
      if (this.selectedOperator == '/') {
        if (this.number2 == 0)
          throw new RangeError("Attempt to divide by zero");
        return Math.floor(this.number1 / this.number2);
      }
      else
        return this.number1 + this.number2;
    }
    catch (error) {
      let now: Date = new Date();
      if (this.timeGuard != null && (now.getTime() - this.timeGuard.getTime()) < 1000)
        return null;
      this.timeGuard = now;
      this.templeAudioService.playThunder();
      setTimeout(() => this.router.navigate(['temple', RoomComponent.roomNameFromRoomId(9)]), 500);
      return null;
    }
  }

  protected updateNumber1(event: any) {
    this.number1 = event.value;
  }

  protected updateNumber2(event: any) {
    this.number2 = event.value;
  }
}
