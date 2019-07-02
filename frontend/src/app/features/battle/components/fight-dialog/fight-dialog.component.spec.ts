import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FightDialogComponent } from './fight-dialog.component';

describe('FightDialogComponent', () => {
  let component: FightDialogComponent;
  let fixture: ComponentFixture<FightDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FightDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FightDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
