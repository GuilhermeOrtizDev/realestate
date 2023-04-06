import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RowImmobilesComponent } from './row-immobiles.component';

describe('RowImmobilesComponent', () => {
  let component: RowImmobilesComponent;
  let fixture: ComponentFixture<RowImmobilesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RowImmobilesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RowImmobilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
