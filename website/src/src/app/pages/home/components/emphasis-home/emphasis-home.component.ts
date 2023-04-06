import { Component, OnInit } from '@angular/core';
import { FilterImmobileModel } from 'src/app/_models/immbolie/filter-immobile.model';
import { ImmobileModel } from 'src/app/_models/immbolie/immobile.model';
import { ImmbolieService } from 'src/app/_services/immbolie.service';

@Component({
  selector: 'app-emphasis-home',
  templateUrl: './emphasis-home.component.html',
  styleUrls: ['./emphasis-home.component.css']
})
export class EmphasisHomeComponent implements OnInit {

  public immobiles: Array<ImmobileModel> = new Array<ImmobileModel>();

  constructor(private _immbolieService: ImmbolieService) { }

  ngOnInit(): void {
    this.get();
  }

  private get(){
    var filter = new FilterImmobileModel();
    filter.amount = 4;

    this._immbolieService.Filter(filter).subscribe({
      next: (res) => { this.immobiles = res },
      error: (error) => {  console.log(error) }
    });
  }

}
