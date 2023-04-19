import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faToilet, IconDefinition } from '@fortawesome/free-solid-svg-icons';
import { ImmobileModel } from 'src/app/_models/immobile.model';

@Component({
  selector: 'app-card-immobile',
  templateUrl: './card-immobile.component.html',
  styleUrls: ['./card-immobile.component.css']
})
export class CardImmobileComponent implements OnInit {

  public toilet: IconDefinition = faToilet;
  public styleImmobile = {};
  @Input() public immobile: ImmobileModel = new ImmobileModel();
  
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  public openImmobile(refe: any){
    this.router.navigateByUrl(`imovel/${refe}`)
  }

  public hoverImmobile(){
    this.styleImmobile = { "opacity" : "0.5" };
  }

  public outImmobile(){
    this.styleImmobile = { "opacity" : "1" };
  }

}
