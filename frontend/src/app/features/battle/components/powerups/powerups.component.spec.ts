import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PowerupsComponent } from './powerups.component';

describe('PowerupsComponent', () => {
  let component: PowerupsComponent;
  let fixture: ComponentFixture<PowerupsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PowerupsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PowerupsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
