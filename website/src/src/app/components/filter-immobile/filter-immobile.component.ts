import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CityModel } from 'src/app/_models/immbolie/city.model';
import { NeighborhoodModel } from 'src/app/_models/immbolie/neighborhood.model';
import { CityService } from 'src/app/_services/city.service';
import { NeighborhoodService } from 'src/app/_services/neighborhood.service';

@Component({
  selector: 'app-filter-immobile',
  templateUrl: './filter-immobile.component.html',
  styleUrls: ['./filter-immobile.component.css']
})
export class FilterImmobileComponent implements OnInit {

  public ref: any; 
  public city: any;
  public neighborhood: any;

  public cities: Array<CityModel> = new Array<CityModel>;
  public neighborhoods: Array<NeighborhoodModel> = new Array<NeighborhoodModel>;
  public _neighborhoods: Array<NeighborhoodModel> = new Array<NeighborhoodModel>;

  public filterImmobile: FormGroup = this._formBuilder.group({
    ref: [''],
    city: [''],
    neighborhood: new FormControl({value: '', disabled: true}),
  });

  constructor(
    private _formBuilder: FormBuilder,
    private _router: Router,
    private _route: ActivatedRoute,
    private _cityService: CityService,
    private _neighborhoodService: NeighborhoodService) { }

  ngOnInit(): void {
    this._route.queryParamMap.subscribe((p) => {
      this.ref = p.get("ref") ?? "";
      this.city = p.get("cidade") ?? "";
      this.neighborhood = p.get("bairro") ?? "";
    });

    this._cityService.All().subscribe({
      next: (res) => { 
        this.cities = res;
        if(this.city != "")
          this.enableNeighborhood(this.city);
      },
      error: (error) => {  console.log(error) }
    });

    this._neighborhoodService.All().subscribe({
      next: (res) => { 
        this._neighborhoods = res;
        if(this.city != "")
          this.enableNeighborhood(this.city);
      },
      error: (error) => {  console.log(error) }
    });
  }

  public submitForm() {
    var url = "imoveis?";
    const filter = this.filterImmobile.value;

    if(typeof filter.ref != 'undefined' && filter.ref)
      url += `ref=${filter.ref}&`;

    if(typeof filter.city != 'undefined' && filter.city)
      url += `cidade=${filter.city}&`;

    if(typeof filter.neighborhood != 'undefined' && filter.neighborhood)
      url += `bairro=${filter.neighborhood}&`;

      url += ";";
      url = url.replace("?;", "").replace("&;", "");

      this._router.navigateByUrl(`${url}`);
  }

  public changeCity(){
    const filter = this.filterImmobile.value;

    if(filter.city == ""){
      this.filterImmobile.controls['neighborhood'].disable();
      this.filterImmobile.controls['neighborhood'].setValue("");
    }
    else{
      this.enableNeighborhood(filter.city);
    }
  }

  private enableNeighborhood(city: any){
    if(this.cities?.length == 0 && this._neighborhoods?.length == 0)
      return;

    var cityId = this.cities.find(c => city === c.description)?.id;
    this.neighborhoods = this._neighborhoods.filter(c => cityId === c.cityId);
    this.filterImmobile.controls['neighborhood'].enable();
  }

}
