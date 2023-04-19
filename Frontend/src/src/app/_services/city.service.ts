import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { CityModel } from '../_models/city.model';
import { Services } from './services';
import { MessageService } from './message.service';
import { MessageModel } from '../_models/message.model';
import { TypeMessageEnum } from '../_enums/type-message.enum';

@Injectable({
  providedIn: 'root'
})
export class CityService extends Services {

  constructor(messageService: MessageService,
    private http: HttpClient) {
    super(messageService);
  }

  public Get(id: any): Observable<CityModel>{
    return this.http.get<CityModel>(`${this.urlCity}/${id}`);
  }

  public All(): Observable<Array<CityModel>>{
    return this.http.get<Array<CityModel>>(`${this.urlCity}/all`);
  }

  public Create(city: CityModel): Observable<number>{
    return this.http.post<number>(`${this.urlCity}`, city ).pipe(
      tap(r => {
        let messages = new Array<MessageModel>();
        messages.push({...new MessageModel(TypeMessageEnum.Succeed, `Cidade de ${city.description} criada`)});
        this.messageService.showMessages(messages);
      }),
       res => res,
       error => error,
    );
  }
}
