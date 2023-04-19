import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardImmobileComponent } from './card-immobile.component';

describe('CardImmobileComponent', () => {
  let component: CardImmobileComponent;
  let fixture: ComponentFixture<CardImmobileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CardImmobileComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CardImmobileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
