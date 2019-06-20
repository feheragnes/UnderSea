import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FightsComponent } from './fights.component';

describe('FightsComponent', () => {
  let component: FightsComponent;
  let fixture: ComponentFixture<FightsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FightsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FightsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
