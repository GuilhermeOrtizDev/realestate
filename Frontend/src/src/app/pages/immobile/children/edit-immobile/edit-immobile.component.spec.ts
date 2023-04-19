import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditImmobileComponent } from './edit-immobile.component';

describe('EditImmobileComponent', () => {
  let component: EditImmobileComponent;
  let fixture: ComponentFixture<EditImmobileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditImmobileComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditImmobileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
