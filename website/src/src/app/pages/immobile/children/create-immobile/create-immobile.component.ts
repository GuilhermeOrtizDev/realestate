import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CityModel } from 'src/app/_models/immbolie/city.model';
import { ImmobileModel } from 'src/app/_models/immbolie/immobile.model';
import { NeighborhoodModel } from 'src/app/_models/immbolie/neighborhood.model';
import { UFModel } from 'src/app/_models/immbolie/uf.model';
import { CityService } from 'src/app/_services/city.service';
import { ImmbolieService } from 'src/app/_services/immbolie.service';
import { NeighborhoodService } from 'src/app/_services/neighborhood.service';
import { UFService } from 'src/app/_services/uf.service';

@Component({
  selector: 'app-create-immobile',
  templateUrl: './create-immobile.component.html',
  styleUrls: ['./create-immobile.component.css']
})
export class CreateImmobileComponent implements OnInit {

  private _image: any;
  private _gallery: Array<any> = [];

  public ufs: Array<UFModel> = new Array<UFModel>;
  public cities: Array<CityModel> = new Array<CityModel>;
  public neighborhoods: Array<NeighborhoodModel> = new Array<NeighborhoodModel>;
  public _cities: Array<CityModel> = new Array<CityModel>;
  public _neighborhoods: Array<NeighborhoodModel> = new Array<NeighborhoodModel>;

  public createImmobile: FormGroup = this._formBuilder.group({
    reference: ['', Validators.required],
    price: ['', Validators.required],
    cep: ['', [Validators.required]],
    uf: ['', [Validators.required]],
    city: new FormControl({value: '', disabled: true}, Validators.required),
    neighborhood: new FormControl({value: '', disabled: true}, Validators.required),
    logradouro: ['', [Validators.required]],
    complement: [''],
    number: ['', [Validators.required]],
    description: ['', [Validators.required]],
    image: ['', [Validators.required]],
    gallery: [''],
  });

  public createUf: FormGroup = this._formBuilder.group({
    uf: ['', [Validators.required]],
  });

  public createCity: FormGroup = this._formBuilder.group({
    city: ['', [Validators.required]],
    uf: ['', [Validators.required]],
  });

  public createNeighborhood: FormGroup = this._formBuilder.group({
    neighborhood: ['', [Validators.required]],
    city: ['', [Validators.required]],
  });

  constructor(
    private _router: Router,
    private _formBuilder: FormBuilder,
    private _immbolieService: ImmbolieService,
    private _ufService: UFService,
    private _cityService: CityService,
    private _neighborhoodService: NeighborhoodService) { }

  ngOnInit(): void {
    this.get();
  }

  public submitForm() {
    var immbolie = new ImmobileModel();
    immbolie = this.createImmobile.value;
    immbolie.uf = this.createImmobile.value.uf.id;
    immbolie.city = this.createImmobile.value.city.id
    immbolie.neighborhood = this.createImmobile.value.neighborhood.id;
    immbolie.image = this._image;
    immbolie.gallery = this._gallery;

    this._immbolieService.Create(immbolie).subscribe( {
      next: (ref) => {
        this._router.navigateByUrl(`imovel/${immbolie.reference}`)
      },
      error: (error) => {  console.log(error) }
    });

  }

  public submitFormUf(){
    var uf = new UFModel();
    uf.description = this.createUf.value.uf;

    this._ufService.Create(uf).subscribe({
      next: (res) => {
        uf.id = res;
        this.ufs.push({...uf}) 
      },
      error: (error) => {  console.log(error) }
    });
  }

  public submitFormCity() {
    var city = new CityModel();
    city.description = this.createCity.value.city;
    city.ufid = this.createCity.value.uf.id;

    this._cityService.Create(city).subscribe({
      next: (res) => {
        city.id = res;
        this.cities.push({...city}) 
      },
      error: (error) => {  console.log(error) }
    });

  }

  public submitFormNeighborhood() {
    var neighborhood = new NeighborhoodModel();
    neighborhood.description = this.createNeighborhood.value.neighborhood;
    neighborhood.cityId = this.createNeighborhood.value.city.id;

    this._neighborhoodService.Create(neighborhood).subscribe({
      next: (res) => {
        neighborhood.id = res;
        this.neighborhoods.push({...neighborhood}) 
      },
      error: (error) => {  console.log(error) }
    });
  }
  
  public changeUF(){
    if(this.createImmobile.get('uf')?.errors){
      this.cities = [];
      this.createImmobile.controls['city'].disable();
    }
    else{
      this.cities = this._cities.filter(c => this.createImmobile.value.uf.id === c.ufid);
      this.createImmobile.controls['city'].enable();
    }
    this.createImmobile.controls['city'].setValue("");
    this.createImmobile.controls['neighborhood'].setValue("");
    this.createImmobile.controls['neighborhood'].disable();
    this.neighborhoods = [];
  }
  
  public changeCity(){
    if(this.createImmobile.get('city')?.errors){
      this.createImmobile.controls['neighborhood'].disable();
      this.createImmobile.controls['neighborhood'].setValue("");
    }
    else{
      this.neighborhoods = this._neighborhoods.filter(c => this.createImmobile.value.city.id === c.cityId);
      this.createImmobile.controls['neighborhood'].enable();
    }
  }
  
  public uploadImage(event: any) {
    var file: File = event.target.files[0];
    this._image = file.name;
  }

  public uploadGallery(event: any) {
    var files: File[] = event.target.files;

    for (const file of files) {
      this._gallery.push(file.name);
    }
  }
  
  private get(){
    this._ufService.All().subscribe({
      next: (res) => { this.ufs = res },
      error: (error) => {  console.log(error) }
    });
  
    this._cityService.All().subscribe({
      next: (res) => { this._cities = res; },
      error: (error) => {  console.log(error) }
    });
  
    this._neighborhoodService.All().subscribe({
      next: (res) => { this._neighborhoods = res },
      error: (error) => {  console.log(error) }
    });
  }
}
