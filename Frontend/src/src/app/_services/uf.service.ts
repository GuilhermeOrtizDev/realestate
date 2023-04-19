import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { UFModel } from '../_models/uf.model';
import { Services } from './services';
import { MessageService } from './message.service';
import { MessageModel } from '../_models/message.model';
import { TypeMessageEnum } from '../_enums/type-message.enum';

@Injectable({
  providedIn: 'root'
})
export class UFService extends Services {
  constructor(messageService: MessageService,
    private http: HttpClient) {
    super(messageService);
  }

  public Get(id: any): Observable<UFModel>{
    return this.http.get<UFModel>(`${this.urlUf}/${id}`);
  }

  public All(): Observable<Array<UFModel>>{
    return this.http.get<Array<UFModel>>(`${this.urlUf}/all`);
  }

  public Create(uf: UFModel): Observable<number>{
    return this.http.post<number>(`${this.urlUf}`, uf ).pipe(
      tap(r => {
        let messages = new Array<MessageModel>();
        messages.push({...new MessageModel(TypeMessageEnum.Succeed, `UF ${uf.description} criada`)});
        this.messageService.showMessages(messages);
      }),
       res => res,
       error => error,
    );
  }
  
}
