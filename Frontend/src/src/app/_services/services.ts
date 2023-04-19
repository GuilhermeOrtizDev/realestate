import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class Services {
  private _url: string = `${environment.url}`;

  private _urlImmboile: string = `${this._url}/Immobile`;
  private _urlUf: string = `${this._url}/UF`;
  private _urlCity: string = `${this._url}/City`;
  private _urlNeighborhood: string = `${this._url}/Neighborhood`;
  
  constructor(public messageService: MessageService) {
    
  }

  protected get urlImmboile() {
    return this._urlImmboile;
  }

  protected get urlUf() {
    return this._urlUf;
  }

  protected get urlCity() {
    return this._urlCity;
  }

  protected get urlNeighborhood() {
    return this._urlNeighborhood;
  }
}
