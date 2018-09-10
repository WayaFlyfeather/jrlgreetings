import { Component } from '@angular/core';
import { TempleAudioService } from './temple-audio.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Greetings from JRL';

  constructor(private templeAudioService: TempleAudioService) {
    this.templeAudioService.initialize();
  }
}
