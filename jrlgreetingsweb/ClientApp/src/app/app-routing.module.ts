import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TempleEntranceComponent } from './temple-entrance/temple-entrance.component';
import { RoomComponent } from './room/room.component';
import { TempleComponent } from './temple/temple.component';

const appRoutes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    {
        path: 'temple', component: TempleComponent, children: [
            { path: '', component: TempleEntranceComponent, pathMatch: 'full' },
            { path: 'northwest', component: RoomComponent, data: { roomId: 0 } },
            { path: 'north', component: RoomComponent, data: { roomId: 1 } },
            { path: 'northeast', component: RoomComponent, data: { roomId: 2 } },
            { path: 'west', component: RoomComponent, data: { roomId: 3 } },
            { path: 'central', component: RoomComponent, data: { roomId: 4 } },
            { path: 'east', component: RoomComponent, data: { roomId: 5 } },
            { path: 'southwest', component: RoomComponent, data: { roomId: 6 } },
            { path: 'south', component: RoomComponent, data: { roomId: 7 } },
            { path: 'southeast', component: RoomComponent, data: { roomId: 8 } },
            { path: 'exceptional', component: RoomComponent, data: { roomId: 9 } },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
