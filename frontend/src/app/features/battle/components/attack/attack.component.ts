import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-attack',
  templateUrl: './attack.component.html',
  styleUrls: ['./attack.component.scss']
})
export class AttackComponent implements OnInit {
  private capaNumber = 0;
  private fokaNumber = 0;
  private csikoNumber = 0;
  inputChanged(type: string, value: number) {
    switch (type) {
      case 'csiko':
        this.csikoNumber = value;

        break;
      case 'foka':
        this.fokaNumber = value;

        break;
      case 'capa':
        this.capaNumber = value;
        break;
    }
  }

  constructor() {}

  ngOnInit() {}
}
