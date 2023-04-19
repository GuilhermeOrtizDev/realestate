import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { NeighborhoodModel } from '../_models/neighborhood.model';
import { Services } from './services';
import { MessageService } from './message.service';
import { MessageModel } from '../_models/message.model';
import { TypeMessageEnum } from '../_enums/type-message.enum';

@Injectable({
  providedIn: 'root'
})
export class NeighborhoodService extends Services {
  constructor(messageService: MessageService,
    private http: HttpClient) {
    super(messageService);
  }

  public Get(id: any): Observable<NeighborhoodModel>{
    return this.http.get<NeighborhoodModel>(`${this.urlNeighborhood}/${id}`);
  }

  public All(): Observable<Array<NeighborhoodModel>>{
    return this.http.get<Array<NeighborhoodModel>>(`${this.urlNeighborhood}/all`);
  }

  public Create(neighborhood: NeighborhoodModel): Observable<number>{
    return this.http.post<number>(`${this.urlNeighborhood}`, neighborhood ).pipe(
      tap(r => {
        let messages = new Array<MessageModel>();
        messages.push({...new MessageModel(TypeMessageEnum.Succeed, `Bairro ${neighborhood.description} criado`)});
        this.messageService.showMessages(messages);
      }),
       res => res,
       error => error,
    );
  }
  
}
