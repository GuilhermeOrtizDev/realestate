import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ImmobileModel } from '../_models/immbolie/immobile.model';
import { Observable } from 'rxjs';
import { FilterImmobileModel } from '../_models/immbolie/filter-immobile.model';

@Injectable({
  providedIn: 'root'
})
export class ImmbolieService {
  private _url: string = "https://localhost:44328/api/v1/Immobile";

  constructor(private http: HttpClient) {
    
  }

  public Get(id: any): Observable<ImmobileModel>{
    return this.http.get<ImmobileModel>(`${this._url}/${id}`);
  }

  public GetWithRef(refe: any): Observable<ImmobileModel>{
    return this.http.get<ImmobileModel>(`${this._url}/ref/${refe}`);
  }

  public Count(filter: FilterImmobileModel): Observable<number>{
    var param = this.FromQuery(filter);
    return this.http.get<number>(`${this._url}/count${param}`);
  }

  public Filter(filter: FilterImmobileModel): Observable<Array<ImmobileModel>>{
    var param = this.FromQuery(filter);

    if(typeof filter.page != 'undefined' && filter.page)
      param += `page=${filter.page}&`;
    
    if(typeof filter.amount != 'undefined' && filter.amount)
      param += `amount=${filter.amount}&`;

    param += ";";
    param = param.replace("&;", "").replace("?;", "");

    return this.http.get<Array<ImmobileModel>>(`${this._url}${param}`);
  }

  public Create(immobile: ImmobileModel): Observable<number>{
    return this.http.post<number>(`${this._url}`, immobile ).pipe(
       res => res,
       error => error,
    );
  }

  public Edit(immobile: ImmobileModel) : Observable<number>{
    return this.http.put<number>(`${this._url}`, immobile ).pipe(
      res => res,
      error => error,
   );
  }

  public Delete(id: any){
    this.http.delete<void>(`${this._url}?id=${id}`).subscribe({
      next: (res) => res,
      error: (error) => error,
    });
  }

  private FromQuery(filter: FilterImmobileModel) : string{
    var param = "?";

    if(typeof filter.refe != 'undefined' && filter.refe)
      param += `reference=${filter.refe}&`;

    if(typeof filter.city != 'undefined' && filter.city)
      param += `city=${filter.city}&`;

    if(typeof filter.neighborhood != 'undefined' && filter.neighborhood)
      param += `neighborhood=${filter.neighborhood}&`;

    return param;
  }
  
}
