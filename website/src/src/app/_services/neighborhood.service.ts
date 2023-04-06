import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { NeighborhoodModel } from '../_models/immbolie/neighborhood.model';

@Injectable({
  providedIn: 'root'
})
export class NeighborhoodService {
  private _url: string = "https://localhost:44328/api/v1/Neighborhood";

  constructor(private http: HttpClient) {
    
  }

  public Get(id: any): Observable<NeighborhoodModel>{
    return this.http.get<NeighborhoodModel>(`${this._url}/${id}`);
  }

  public All(): Observable<Array<NeighborhoodModel>>{
    return this.http.get<Array<NeighborhoodModel>>(`${this._url}/all`);
  }

  public Create(neighborhood: NeighborhoodModel): Observable<number>{
    return this.http.post<number>(`${this._url}`, neighborhood ).pipe(
       res => res,
       error => error,
    );
  }
  
}
