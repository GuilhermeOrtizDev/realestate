import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FilterImmobileModel } from 'src/app/_models/immbolie/filter-immobile.model';
import { ImmobileModel } from 'src/app/_models/immbolie/immobile.model';
import { ImmbolieService } from 'src/app/_services/immbolie.service';

@Component({
  selector: 'app-immobile',
  templateUrl: './immobile.component.html',
  styleUrls: ['./immobile.component.css']
})

export class ImmobileComponent implements OnInit {

  public immobile: ImmobileModel = new ImmobileModel();
  public immobiles: Array<ImmobileModel> = new Array<ImmobileModel>();
  private _ref: any; 

  constructor(
    private _immbolieService: ImmbolieService,
    private _route: ActivatedRoute,
    private _router: Router) { }

  ngOnInit(): void {
    this._route.params.subscribe((p) => {
      this._ref = p["ref"];
    });
    
    this.get();
  }

  private get(){
    this._immbolieService.GetWithRef(this._ref).subscribe({
      next: (res) => { this.immobile = res },
      error: (error) => {  console.log(error) }
    });

    var filter = new FilterImmobileModel();
    filter.amount = 4;

    this._immbolieService.Filter(filter).subscribe({
      next: (res) => { this.immobiles = res },
      error: (error) => {  console.log(error) }
    });
  }

  public editImmobile(){
    this._router.navigateByUrl(`imovel/${this._ref}/editar`)
  }

  public deletImmobile(){
    this._immbolieService.Delete(this.immobile.id);
  }

}
