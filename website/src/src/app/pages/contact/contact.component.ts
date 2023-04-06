import { Component, OnInit } from '@angular/core';
import { faWhatsapp, faInstagram, faFacebook } from '@fortawesome/free-brands-svg-icons';
import { faEnvelope } from '@fortawesome/free-regular-svg-icons';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  public faWhatsapp = faWhatsapp;
  public faInstagram = faInstagram;
  public faFacebook = faFacebook;
  public faEnvelope = faEnvelope;

  constructor() { }

  ngOnInit(): void {
  }

}
