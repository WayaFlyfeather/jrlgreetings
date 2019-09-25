import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TempleEntranceComponent } from './temple-entrance/temple-entrance.component';
import { RoomComponent } from './room/room.component';

const appRoutes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'temple', component: TempleEntranceComponent, pathMatch: 'full' },
    { path: 'temple/northwest', component: RoomComponent, data: { roomId: 0 } },
    { path: 'temple/north', component: RoomComponent, data: { roomId: 1 } },
    { path: 'temple/northeast', component: RoomComponent, data: { roomId: 2 } },
    { path: 'temple/west', component: RoomComponent, data: { roomId: 3 } },
    { path: 'temple/central', component: RoomComponent, data: { roomId: 4 } },
    { path: 'temple/east', component: RoomComponent, data: { roomId: 5 } },
    { path: 'temple/southwest', component: RoomComponent, data: { roomId: 6 } },
    { path: 'temple/south', component: RoomComponent, data: { roomId: 7 } },
    { path: 'temple/southeast', component: RoomComponent, data: { roomId: 8 } },
    { path: 'temple/exceptional', component: RoomComponent, data: { roomId: 9 } },
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
