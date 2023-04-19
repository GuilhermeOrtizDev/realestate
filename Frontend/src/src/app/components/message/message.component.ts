import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { TypeMessageEnum } from 'src/app/_enums/type-message.enum';
import { MessageModel } from 'src/app/_models/message.model';
import { MessageService } from 'src/app/_services/message.service';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent implements OnInit {

  public messages: Array<MessageModel> = new Array<MessageModel>();
  subscription: Subscription;

  constructor(public messageService: MessageService) {
    this.subscription = this.messageService.getMessages().subscribe(messages => {
      if (messages) 
        this.setMessages(messages);
    });
  }

  ngOnInit(): void {
  }

  private setMessages(messages: Array<MessageModel>){
    for(let i = 0; i < messages.length; i++){
      setTimeout(() =>{
        this.setMessage(messages[i].type, messages[i].message);
      }, (500 * i));
    }
  }

  private setMessage(type: TypeMessageEnum, message: string){
    this.messages.push({...new MessageModel(type, message)});

    setTimeout(() =>{
      this.messages.splice(0, 1)
    }, 5000);
  } 

}
