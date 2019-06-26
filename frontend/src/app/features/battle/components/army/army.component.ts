import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { EgysegService } from '../../services/egyseg.service';

@Component({
  selector: 'app-army',
  templateUrl: './army.component.html',
  styleUrls: ['./army.component.scss']
})
export class ArmyComponent implements OnInit {
  private capaNumber = 0;
  private fokaNumber = 0;
  private csikoNumber = 0;
  private egysegInfo;
  capaInfo;
  csikoInfo;
  fokaInfo;
  @Output() stateChanged = new EventEmitter();

  constructor(private egysegService: EgysegService) {}

  ngOnInit() {
    this.getEgysegInfo();
  }

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

  getEgysegInfo() {
    this.egysegService.getEgysegInfo().subscribe(
      data => {
        this.egysegInfo = data;
        console.log(this.egysegInfo);
        data.forEach(element => {
          if (element.tipus === 'RohamFoka') {
            this.fokaInfo = element;
          }
          if (element.tipus === 'LezerCapa') {
            this.capaInfo = element;
          }
          if (element.tipus === 'CsataCsiko') {
            this.csikoInfo = element;
          }
        });
      },
      err => console.error(err),
      () => {
        console.log('done loading egysegInfo');
      }
    );
  }

  buyEgyseg() {}
}
