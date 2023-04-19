import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { MessageModel } from '../_models/message.model';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  
  public messages = new Subject();

  constructor() {
  }

  public showMessages(messages: Array<MessageModel>){
    this.messages.next(messages);
  }

  public getMessages(): Observable<any> {
    return this.messages.asObservable();
}

}
