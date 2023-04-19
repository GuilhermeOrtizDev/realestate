import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmphasisHomeComponent } from './emphasis-home.component';

describe('EmphasisHomeComponent', () => {
  let component: EmphasisHomeComponent;
  let fixture: ComponentFixture<EmphasisHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmphasisHomeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmphasisHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
