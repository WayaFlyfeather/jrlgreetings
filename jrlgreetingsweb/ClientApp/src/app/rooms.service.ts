import { Injectable } from '@angular/core';
import { Room } from './room';
import { Temple } from './temple';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap, count } from 'rxjs/operators';

@Injectable()
export class RoomsService {

  private fetchedRooms: Room[] = null;
  private temple = new Temple();
  private roomsUrl = 'api/rooms';
  constructor(private http: HttpClient) { }

  getRooms(): Observable<Room[]> {
    if (this.fetchedRooms == null)
      return this.http.get<Room[]>(this.roomsUrl)
        .pipe(
          tap(rooms => { this.fetchedRooms = rooms; this.countCompleted(); }),
          catchError(this.handleError('getRooms', []))
        );
    else
      return of(this.fetchedRooms);
  }

  getRoom(roomId: number): Observable<Room> {
    if (this.fetchedRooms == null)
      return this.getRooms()
        .pipe(
          map(rooms => { return rooms[roomId] })
      );
    else
      return of(this.fetchedRooms[roomId]);
  }

  updateRoom(room: Room): Observable<Room> {
    if (room != null)
      this.fetchedRooms[room.roomNo] = room;

    this.countCompleted();
    return of(room);
  }

  getTemple(): Observable<Temple> {
   return of(this.temple);
  }


  countCompleted(): void {
    let countComplete: number = 0;
    let countNotComplete: number = 0;
    if (this.fetchedRooms != null) {
      for (let room of this.fetchedRooms) {
        if (room.completed)
          countComplete++;
        else
          countNotComplete++;
      }
    }
    this.temple.completedRoomsCount = countComplete;
    this.temple.notCompletedRoomsCount = countNotComplete;
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

}
