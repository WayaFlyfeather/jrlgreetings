import { Injectable } from '@angular/core';

@Injectable()
export class TempleAudioService {
  private footsteps: HTMLAudioElement;
  private click: HTMLAudioElement;
  private thunder: HTMLAudioElement;
  constructor() { }

  initialize(): void {
    setTimeout(() => {
      this.footsteps = new Audio();
      this.footsteps.src = '/assets/footsteps.mp3';
      this.footsteps.load();

      this.click = new Audio();
      this.click.src = '/assets/click.mp3';
      this.click.load();

      this.thunder = new Audio();
      this.thunder.src = '/assets/thunder.mp3';
      this.thunder.load();

    }, 10);
  }

  playFootsteps(): void {
    this.footsteps.play();
  }

  playThunder(): void {
    this.thunder.play();
  }

  playClick(): void {
    this.click.play();
  }
}
