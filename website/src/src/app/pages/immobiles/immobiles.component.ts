import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { CityModel } from 'src/app/_models/immbolie/city.model';
import { FilterImmobileModel } from 'src/app/_models/immbolie/filter-immobile.model';
import { ImmobileModel } from 'src/app/_models/immbolie/immobile.model';
import { NeighborhoodModel } from 'src/app/_models/immbolie/neighborhood.model';
import { CityService } from 'src/app/_services/city.service';
import { ImmbolieService } from 'src/app/_services/immbolie.service';
import { NeighborhoodService } from 'src/app/_services/neighborhood.service';


@Component({
  selector: 'app-immobiles',
  templateUrl: './immobiles.component.html',
  styleUrls: ['./immobiles.component.css']
})
export class ImmobilesComponent implements OnInit {
  public immobiles: Array<ImmobileModel> = new Array<ImmobileModel>();
  public amount: number = 0;

  private _ref: any; 
  private _city: any;
  private _neighborhood: any;
  private _page: number = 1;
  private _cities: Array<CityModel> = new Array<CityModel>;
  private _neighborhoods: Array<NeighborhoodModel> = new Array<NeighborhoodModel>;

  constructor(
    private _immbolieService: ImmbolieService,
    private _cityService: CityService,
    private _neighborhoodService: NeighborhoodService,
    private _route: ActivatedRoute,
    private _router: Router) { }

  ngOnInit(): void {
    this._cityService.All().subscribe({
      next: (res) => { 
        this._cities = res;
        this.Filter();
      },
      error: (error) => {  console.log(error) }
    });

    this._neighborhoodService.All().subscribe({
      next: (res) => { 
        this._neighborhoods = res;
        this.Filter();
      },
      error: (error) => {  console.log(error) }
    });

    this._router.events.subscribe((event) => {
      if (event instanceof NavigationEnd){
        this.Filter();
      }
    });
  }

  private Filter(){
    if(this._cities?.length == 0 && this._neighborhoods?.length == 0)
      return;

    this._page = parseInt(this._route.snapshot.paramMap.get('page') ?? "1");  

    this._route.queryParamMap.subscribe((p) => {
      this._ref = p.get("ref") ?? "";
      this._city = p.get("cidade") ?? "";
      this._neighborhood = p.get("bairro") ?? "";
    });

    var filter = new FilterImmobileModel();
    filter.refe = this._ref;
    filter.city = this._cities.find(c => this._city === c.description)?.id;
    filter.neighborhood = this._neighborhoods.find(c => this._neighborhood === c.description)?.id;
    filter.page = this._page;

    this._immbolieService.Filter(filter).subscribe({
      next: (res) => { this.immobiles = res },
      error: (error) => {  console.log(error) }
    });

    this._immbolieService.Count(filter).subscribe({
      next: (res) => { this.amount = Math.ceil(res / 12) },
      error: (error) => {  console.log(error) }
    });
  }

}
