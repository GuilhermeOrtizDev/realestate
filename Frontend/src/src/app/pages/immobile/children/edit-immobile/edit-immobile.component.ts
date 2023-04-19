import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CityModel } from 'src/app/_models/city.model';
import { ImmobileModel } from 'src/app/_models/immobile.model';
import { NeighborhoodModel } from 'src/app/_models/neighborhood.model';
import { UFModel } from 'src/app/_models/uf.model';
import { CityService } from 'src/app/_services/city.service';
import { ImmbolieService } from 'src/app/_services/immbolie.service';
import { NeighborhoodService } from 'src/app/_services/neighborhood.service';
import { UFService } from 'src/app/_services/uf.service';

@Component({
  selector: 'app-edit-immobile',
  templateUrl: './edit-immobile.component.html',
  styleUrls: ['./edit-immobile.component.css']
})
export class EditImmobileComponent implements OnInit {

  private _image: any;
  private _ref: any;
  private _gallery: Array<any> = [];

  public getImage: any;
  public getGallery: any;

  public immobile: ImmobileModel = new ImmobileModel;
  public ufs: Array<UFModel> = new Array<UFModel>;
  public cities: Array<CityModel> = new Array<CityModel>;
  public neighborhoods: Array<NeighborhoodModel> = new Array<NeighborhoodModel>;
  public _cities: Array<CityModel> = new Array<CityModel>;
  public _neighborhoods: Array<NeighborhoodModel> = new Array<NeighborhoodModel>;

  public editImmobile: FormGroup = this._formBuilder.group({
    reference: ['', Validators.required],
    price: ['', Validators.required],
    cep: ['', [Validators.required]],
    uf: ['', [Validators.required]],
    city: new FormControl({value: '', disabled: false}, Validators.required),
    neighborhood: new FormControl({value: '', disabled: false}, Validators.required),
    logradouro: ['', [Validators.required]],
    complement: [''],
    number: ['', [Validators.required]],
    description: ['', [Validators.required]],
    image: [''],
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
    private _route: ActivatedRoute,
    private _formBuilder: FormBuilder,
    private _immbolieService: ImmbolieService,
    private _ufService: UFService,
    private _cityService: CityService,
    private _neighborhoodService: NeighborhoodService) { }

  ngOnInit(): void {
    this._route.params.subscribe((p) => {
      this._ref = p["ref"];
    });

    this.get();
  }

  public submitForm() {
    var immbolie = new ImmobileModel();
    immbolie = this.editImmobile.value;
    immbolie.uf = this.editImmobile.value.uf;
    immbolie.city = this.editImmobile.value.city
    immbolie.neighborhood = this.editImmobile.value.neighborhood;
    immbolie.image = this._image;
    immbolie.gallery = this._gallery;
    immbolie.id = this.immobile.id;

    if(immbolie.image == undefined || immbolie.image == "")
      immbolie.image = this.immobile.image;

    if(immbolie.gallery == undefined || immbolie.gallery == "")
      immbolie.gallery = this.immobile.gallery;

    this._immbolieService.Edit(immbolie).subscribe( {
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
    if(this.editImmobile.get('uf')?.errors){
      this.cities = [];
      this.editImmobile.controls['city'].disable();
    }
    else{
      this.cities = this._cities.filter(c => this.editImmobile.value.uf === c.ufid);
      this.editImmobile.controls['city'].enable();
    }
    this.editImmobile.controls['city'].setValue("");
    this.editImmobile.controls['neighborhood'].setValue("");
    this.editImmobile.controls['neighborhood'].disable();
    this.neighborhoods = [];
  }
  
  public changeCity(){
    if(this.editImmobile.get('city')?.errors){
      this.editImmobile.controls['neighborhood'].disable();
      this.editImmobile.controls['neighborhood'].setValue("");
    }
    else{
      this.neighborhoods = this._neighborhoods.filter(c => this.editImmobile.value.city === c.cityId);
      this.editImmobile.controls['neighborhood'].enable();
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
    this._immbolieService.GetWithRef(this._ref).subscribe({
      next: (res) => { 
        this.immobile = res; 
        this.getSelecteds(); 
        this.getFiles();
      },
      error: (error) => {  console.log(error) }
    });
  }

  private getSelecteds(){
    this._ufService.All().subscribe({
      next: (res) => { this.ufs = res },
      error: (error) => {  console.log(error) }
    });
  
    this._cityService.All().subscribe({
      next: (res) => { 
        this._cities = res; 
        this.cities = this._cities.filter(c => this.immobile.uf.id === c.ufid);
      },
      error: (error) => {  console.log(error) }
    });
  
    this._neighborhoodService.All().subscribe({
      next: (res) => { this._neighborhoods = res; this.changeCity() },
      error: (error) => {  console.log(error) }
    });
  }

  private getFiles(){
    //this.getImage = `./assets/uploads/images/${this.immobile.image}`;
    //this.getGallery = `${this.immobile.gallery}`;
  }
}
