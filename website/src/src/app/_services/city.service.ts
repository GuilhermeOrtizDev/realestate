import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CityModel } from '../_models/immbolie/city.model';

@Injectable({
  providedIn: 'root'
})
export class CityService {
  private _url: string = "https://localhost:44328/api/v1/City";

  constructor(private http: HttpClient) {
    
  }

  public Get(id: any): Observable<CityModel>{
    return this.http.get<CityModel>(`${this._url}/${id}`);
  }

  public All(): Observable<Array<CityModel>>{
    return this.http.get<Array<CityModel>>(`${this._url}/all`);
  }

  public Create(city: CityModel): Observable<number>{
    return this.http.post<number>(`${this._url}`, city ).pipe(
       res => res,
       error => error,
    );
  }
}
