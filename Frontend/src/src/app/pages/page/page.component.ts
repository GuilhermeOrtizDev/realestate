import { HttpErrorResponse, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import {  Observable, catchError, throwError } from 'rxjs';
import { TypeMessageEnum } from 'src/app/_enums/type-message.enum';
import { MessageModel } from 'src/app/_models/message.model';
import { MessageService } from 'src/app/_services/message.service';

@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.css']
})
export class PageComponent implements OnInit, HttpInterceptor {
  constructor(public messageService: MessageService) {
    
  }

  ngOnInit(): void {

  }

  intercept(request: HttpRequest<any>, next: HttpHandler) : Observable<any> {
    return next.handle(request)
      .pipe(
        catchError((errorResponse: HttpErrorResponse) => {
          let messages = new Array<MessageModel>();

          if (errorResponse.error instanceof ErrorEvent) {
            //TO DO send
            messages.push({...new MessageModel(TypeMessageEnum.Error, "Erro na requisição")});
          }
          else if (errorResponse.error instanceof ProgressEvent) {
            //TO DO send
            messages.push({...new MessageModel(TypeMessageEnum.Error, "Erro na requisição")});
          }
          else if(errorResponse.error instanceof Array){
            errorResponse.error.forEach((error: Array<string> | any) => {
              if(error)
                messages.push({...new MessageModel(TypeMessageEnum.Error, error)});
            });
          }
          else {
            //TO DO default
            messages.push({...new MessageModel(TypeMessageEnum.Error, "Erro inesperado")});
          }
          this.messageService.showMessages(messages);
          return throwError(() => messages);
        })
      )
    
  }

}