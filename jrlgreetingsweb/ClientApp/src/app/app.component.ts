import { Component } from '@angular/core';
//import { RoomsService } from './rooms.service';
//import { Room } from './room';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Greetings from JRL';
  //private dummyRooms: Room[] = null;

  constructor() { }
  //constructor(private roomsService: RoomsService) {
  //  roomsService.getRooms()
  //    .subscribe(rooms => {
  //      this.dummyRooms = rooms;
  //      console.log('init roomsService' + this.dummyRooms.length);
  //    });
  //}
}
