import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { TamadasService } from '../../services/tamadas.service';
import { ToastrService } from 'ngx-toastr';
import { EgysegType } from '../../models/egyseg';
import { SeregInfo } from '../../models/orszag';
import { TamadasInfo, Tamadas } from '../../models/tamadas';
import { LevelNumbers } from '../../models/levelNumbers';

@Component({
  selector: 'app-attack',
  templateUrl: './attack.component.html',
  styleUrls: ['./attack.component.scss']
})
export class AttackComponent implements OnInit {
  public capaNumber: LevelNumbers;
  public fokaNumber: LevelNumbers;
  public csikoNumber: LevelNumbers;
  public tamadasInfo: TamadasInfo;
  public countries: string[];
  public filteredCountries: string[];
  public selectedCountry: string;
  public fokaInfo: SeregInfo[];
  public capaInfo: SeregInfo[];
  public csikoInfo: SeregInfo[];
  public fokaInfoNumbers: LevelNumbers;
  public capaInfoNumbers: LevelNumbers;
  public csikoInfoNumbers: LevelNumbers;
  @Output() stateChanged = new EventEmitter();

  constructor(
    private tamadasService: TamadasService,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.getTamadasInfos();
    this.setLevelNumbersToZero();
  }

  getTamadasInfos() {
    this.capaInfo = null;
    this.csikoInfo = null;
    this.fokaInfo = null;
    this.capaInfoNumbers = { level1: 0, level2: 0, level3: 0 };
    this.csikoInfoNumbers = { level1: 0, level2: 0, level3: 0 };
    this.fokaInfoNumbers = { level1: 0, level2: 0, level3: 0 };
    this.tamadasService.getTamadasInfo().subscribe(
      data => {
        this.tamadasInfo = data;
        this.countries = data.orszag;
        this.filteredCountries = data.orszag;
        this.fokaInfo = data.sereg.filter(x => x.tipus === EgysegType.foka);
        this.fokaInfo.forEach(element => {
          if (element.szint === 1) {
            this.fokaInfoNumbers.level1 = element.mennyiseg;
          } else if (element.szint === 2) {
            this.fokaInfoNumbers.level2 = element.mennyiseg;
          } else if (element.szint === 3) {
            this.fokaInfoNumbers.level3 = element.mennyiseg;
          }
        });
        this.capaInfo = data.sereg.filter(x => x.tipus === EgysegType.capa);
        this.capaInfo.forEach(element => {
          if (element.szint === 1) {
            this.capaInfoNumbers.level1 = element.mennyiseg;
          } else if (element.szint === 2) {
            this.capaInfoNumbers.level2 = element.mennyiseg;
          } else if (element.szint === 3) {
            this.capaInfoNumbers.level3 = element.mennyiseg;
          }
        });
        this.csikoInfo = data.sereg.filter(x => x.tipus === EgysegType.csiko);
        this.csikoInfo.forEach(element => {
          if (element.szint === 1) {
            this.csikoInfoNumbers.level1 = element.mennyiseg;
          } else if (element.szint === 2) {
            this.csikoInfoNumbers.level2 = element.mennyiseg;
          } else if (element.szint === 3) {
            this.csikoInfoNumbers.level3 = element.mennyiseg;
          }
        });
        console.log(
          this.capaInfoNumbers,
          this.csikoInfoNumbers,
          this.fokaInfoNumbers
        );
      },
      err => console.error(err),
      () => {
        console.log('done loading tamadasInfo');
      }
    );
  }

  search(value: string) {
    this.filteredCountries = this.countries.filter(b => {
      if (b.toUpperCase().includes(value.toUpperCase())) {
        return b;
      }
    });
  }

  selectCountry(country: string) {
    this.selectedCountry = country;
  }

  attack() {
    const parameter: Tamadas = {
      orszag: this.selectedCountry,
      tamadoEgysegek: [
        {
          tipus: EgysegType.foka,
          mennyiseg: this.fokaNumber.level1,
          szint: 1
        },
        {
          tipus: EgysegType.capa,
          mennyiseg: this.capaNumber.level1,
          szint: 1
        },
        {
          tipus: EgysegType.csiko,
          mennyiseg: this.csikoNumber.level1,
          szint: 1
        },
        {
          tipus: EgysegType.foka,
          mennyiseg: this.fokaNumber.level2,
          szint: 2
        },
        {
          tipus: EgysegType.capa,
          mennyiseg: this.capaNumber.level2,
          szint: 2
        },
        {
          tipus: EgysegType.csiko,
          mennyiseg: this.csikoNumber.level2,
          szint: 2
        },
        {
          tipus: EgysegType.foka,
          mennyiseg: this.fokaNumber.level3,
          szint: 3
        },
        {
          tipus: EgysegType.capa,
          mennyiseg: this.capaNumber.level3,
          szint: 3
        },
        {
          tipus: EgysegType.csiko,
          mennyiseg: this.csikoNumber.level3,
          szint: 3
        }
      ]
    };
    console.log(parameter);

    this.tamadasService.tamadas(parameter).subscribe(
      data => {
        console.log(data);
      },
      error => {
        console.log(error);
        this.toastr.error(error, 'Nem sikerült támadni :(');
        this.setLevelNumbersToZero();
        this.selectedCountry = null;
      },
      () => {
        console.log('attacked');
        this.toastr.success('A kör végén lesz eredmény', 'Harc folyamatban!');
        this.stateChanged.emit(null);
        this.setLevelNumbersToZero();
        this.selectedCountry = null;
        this.getTamadasInfos();
      }
    );
  }

  setLevelNumbersToZero() {
    this.capaNumber = { level1: 0, level2: 0, level3: 0 };
    this.csikoNumber = { level1: 0, level2: 0, level3: 0 };
    this.fokaNumber = { level1: 0, level2: 0, level3: 0 };
  }
}
