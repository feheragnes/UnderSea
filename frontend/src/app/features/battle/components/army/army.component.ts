import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-army',
  templateUrl: './army.component.html',
  styleUrls: ['./army.component.scss']
})
export class ArmyComponent implements OnInit {
  private capaNumber = 0;
  private fokaNumber = 0;
  private csikoNumber = 0;

  changeNumber(type: string, value: number) {
    switch (type) {
      case 'csiko':
        if (this.csikoNumber > 0 || value > 0) {
          this.csikoNumber += value;
        }
        break;
      case 'foka':
        if (this.fokaNumber > 0 || value > 0) {
          this.fokaNumber += value;
        }
        break;
      case 'capa':
        if (this.capaNumber > 0 || value > 0) {
          this.capaNumber += value;
        }
        break;
    }
  }

  constructor() {}

  ngOnInit() {}
}
