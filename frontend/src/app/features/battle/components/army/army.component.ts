import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { EgysegService } from '../../services/egyseg.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-army',
  templateUrl: './army.component.html',
  styleUrls: ['./army.component.scss']
})
export class ArmyComponent implements OnInit {
  public capaNumber = 0;
  public fokaNumber = 0;
  public csikoNumber = 0;
  public egysegInfo;
  public capaInfo;
  public csikoInfo;
  public fokaInfo;
  @Output() stateChanged = new EventEmitter();

  constructor(
    private egysegService: EgysegService,
    private toastr: ToastrService
  ) {}

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

  buyEgyseg() {
    const parameter = [
      {
        tipus: 'RohamFoka',
        mennyiseg: this.fokaNumber
      },
      {
        tipus: 'LezerCapa',
        mennyiseg: this.capaNumber
      },
      {
        tipus: 'CsataCsiko',
        mennyiseg: this.csikoNumber
      }
    ];
    this.egysegService.buyEgyseg(parameter).subscribe(
      data => {
        console.log(data);
      },
      error => {
        this.toastr.error(error, 'Nem tudtál sereget venni!');
        console.log(error);
      },
      () => {
        this.toastr.success('Sikeres vásárlás!');
        this.stateChanged.emit(null);
        console.log('bought army');
      }
    );
  }
}
