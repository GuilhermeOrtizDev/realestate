import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ImmobileModel } from '../_models/immobile.model';
import { Observable, tap } from 'rxjs';
import { FilterImmobileModel } from '../_models/filter-immobile.model';
import { Services } from './services';
import { MessageService } from './message.service';
import { MessageModel } from '../_models/message.model';
import { TypeMessageEnum } from '../_enums/type-message.enum';

@Injectable({
  providedIn: 'root'
})
export class ImmbolieService extends Services {
  
  constructor(messageService: MessageService,
    private http: HttpClient) {
    super(messageService);
  }

  public Get(id: any): Observable<ImmobileModel>{
    return this.http.get<ImmobileModel>(`${this.urlImmboile}/${id}`);
  }

  public GetWithRef(refe: any): Observable<ImmobileModel>{
    return this.http.get<ImmobileModel>(`${this.urlImmboile}/ref/${refe}`);
  }

  public Count(filter: FilterImmobileModel): Observable<number>{
    var param = this.FromQuery(filter);
    return this.http.get<number>(`${this.urlImmboile}/count${param}`);
  }

  public Filter(filter: FilterImmobileModel): Observable<Array<ImmobileModel>>{
    var param = this.FromQuery(filter);

    if(typeof filter.page != 'undefined' && filter.page)
      param += `page=${filter.page}&`;
    
    if(typeof filter.amount != 'undefined' && filter.amount)
      param += `amount=${filter.amount}&`;

    param += ";";
    param = param.replace("&;", "").replace("?;", "");

    return this.http.get<Array<ImmobileModel>>(`${this.urlImmboile}${param}`);
  }

  public Create(immobile: ImmobileModel): Observable<number>{
    return this.http.post<number>(`${this.urlImmboile}`, immobile ).pipe(
      tap(r => {
        let messages = new Array<MessageModel>();
        messages.push({...new MessageModel(TypeMessageEnum.Succeed, `Imovel ${immobile.reference} criado`)});
        this.messageService.showMessages(messages);
      }),
       res => res,
       error => error,
    );
  }

  public Edit(immobile: ImmobileModel) : Observable<number>{
    return this.http.put<number>(`${this.urlImmboile}`, immobile ).pipe(
      tap(r => {
        let messages = new Array<MessageModel>();
        messages.push({...new MessageModel(TypeMessageEnum.Succeed, `Imovel ${immobile.reference} editado`)});
        this.messageService.showMessages(messages);
      }),
      res => res,
      error => error,
   );
  }

  public Delete(id: any){
    this.http.delete<void>(`${this.urlImmboile}?id=${id}`).subscribe({
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
