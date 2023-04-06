import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UFModel } from '../_models/immbolie/uf.model';

@Injectable({
  providedIn: 'root'
})
export class UFService {
  private _url: string = "https://localhost:44328/api/v1/UF";

  constructor(private http: HttpClient) {
    
  }

  public Get(id: any): Observable<UFModel>{
    return this.http.get<UFModel>(`${this._url}/${id}`);
  }

  public All(): Observable<Array<UFModel>>{
    return this.http.get<Array<UFModel>>(`${this._url}/all`);
  }

  public Create(uf: UFModel): Observable<number>{
    return this.http.post<number>(`${this._url}`, uf ).pipe(
       res => res,
       error => error,
    );
  }
  
}
