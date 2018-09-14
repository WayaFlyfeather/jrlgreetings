import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TempleAudioService } from '../temple-audio.service';

@Component({
  selector: 'app-temple-entrance',
  templateUrl: './temple-entrance.component.html',
  styleUrls: ['./temple-entrance.component.css']
})
export class TempleEntranceComponent implements OnInit {

  constructor(
    private templeAudioService: TempleAudioService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  enterTemple(): void {
    this.templeAudioService.playFootsteps();
    setTimeout(() => this.router.navigate(['temple', 'northwest']), 500);
  }
}
