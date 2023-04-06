import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterImmobileComponent } from './filter-immobile.component';

describe('FilterImmobileComponent', () => {
  let component: FilterImmobileComponent;
  let fixture: ComponentFixture<FilterImmobileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FilterImmobileComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FilterImmobileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
