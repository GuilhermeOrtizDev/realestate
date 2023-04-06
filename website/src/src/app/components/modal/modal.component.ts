import { DOCUMENT } from '@angular/common';
import { Component, ElementRef, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {

  public id: any;
  public title: any;
  public classModal: any;
  public showModal = {};

  constructor(
    @Inject(DOCUMENT) private document: Document,
    private elRef:ElementRef) { }

  ngOnInit(): void {
    this.id = this.elRef.nativeElement.id;
    this.title = this.elRef.nativeElement.title;
    this.classModal = this.elRef.nativeElement.class;
  }

  public openModal(){
    this.showModal = { "display" : "block" };
    this.document.body.style.overflow = "hidden";
  }

  public closeModal(){
    this.showModal = { "display" : "none" };
    this.document.body.style.overflow = "";
  }

}
