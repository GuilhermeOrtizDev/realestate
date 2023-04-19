import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Subscription, timer } from 'rxjs';

@Component({
  selector: 'app-carrossel',
  templateUrl: './carrossel.component.html',
  styleUrls: ['./carrossel.component.css']
})
export class CarrosselComponent implements OnInit, OnChanges {

  public timerSubs!: Subscription;
  public urlImage = {};
  @Input() public images: string[] = [];

  private _index: number = 0;
  
  constructor() { }
  
  ngOnInit(): void {
    
  }

  ngOnChanges(changes: SimpleChanges): void {
    if(!changes['images'].firstChange)
      this.setImage();
  }

  ngOnDestroy(): void {
    this.stop();
  }

  private start(): void {
    this.timerSubs = timer(5000).subscribe(() => {
      this.setImage();
    });
  }
  
  private setImage(): void {
    if(this.images.length == 0)
      return;

    this.urlImage = { "background-image" : `url(./assets/uploads/images/${this.images[this._index]})` };
    this._index = this._index < this.images.length - 1 ? this._index + 1 : 0;
    this.start();
  }
  
  public stop(): void {
    this.timerSubs?.unsubscribe();
  }
}
