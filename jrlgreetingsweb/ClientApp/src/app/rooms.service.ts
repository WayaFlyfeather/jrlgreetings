import { Injectable } from '@angular/core';
import { Room } from './room';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable()
export class RoomsService {

  private fetchedRooms: Room[] = null;
  private roomsUrl = 'api/rooms';
  constructor(private http: HttpClient) { }

  getRooms(): Observable<Room[]> {
    if (this.fetchedRooms == null)
      return this.http.get<Room[]>(this.roomsUrl)
        .pipe(
          tap(rooms => { this.fetchedRooms = rooms; console.log('fetched rooms'); }),
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
