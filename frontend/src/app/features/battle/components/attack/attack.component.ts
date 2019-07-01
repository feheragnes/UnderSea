import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { TamadasService } from '../../services/tamadas.service';
import { ToastrService } from 'ngx-toastr';
import { EgysegType } from '../../models/egyseg';
import { SeregInfo } from '../../models/orszag';
import { TamadasInfo } from '../../models/tamadas';

@Component({
  selector: 'app-attack',
  templateUrl: './attack.component.html',
  styleUrls: ['./attack.component.scss']
})
export class AttackComponent implements OnInit {
  public capaNumber = 0;
  public fokaNumber = 0;
  public csikoNumber = 0;
  public tamadasInfo: TamadasInfo;
  public countries: string[];
  public filteredCountries: string[];
  public selectedCountry: string;
  public fokaInfo: SeregInfo;
  public capaInfo: SeregInfo;
  public csikoInfo: SeregInfo;
  @Output() stateChanged = new EventEmitter();

  constructor(
    private tamadasService: TamadasService,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.getTamadasInfos();
  }

  getTamadasInfos() {
    this.capaInfo = null;
    this.csikoInfo = null;
    this.fokaInfo = null;
    this.tamadasService.getTamadasInfo().subscribe(
      data => {
        this.tamadasInfo = data;
        this.countries = data.orszag;
        this.filteredCountries = data.orszag;
        data.sereg.forEach(element => {
          if (element.tipus === EgysegType.foka) {
            this.fokaInfo = element;
          }
          if (element.tipus === EgysegType.capa) {
            this.capaInfo = element;
          }
          if (element.tipus === EgysegType.csiko) {
            this.csikoInfo = element;
          }
        });
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
    const parameter = {
      orszag: this.selectedCountry,
      tamadoEgysegek: [
        {
          tipus: EgysegType.foka,
          mennyiseg: this.fokaNumber
        },
        {
          tipus: EgysegType.capa,
          mennyiseg: this.capaNumber
        },
        {
          tipus: EgysegType.csiko,
          mennyiseg: this.csikoNumber
        }
      ]
    };

    this.tamadasService.tamadas(parameter).subscribe(
      data => {
        console.log(data);
      },
      error => {
        console.log(error);
        this.toastr.error(error, 'Nem sikerült támadni :(');
        this.capaNumber = 0;
        this.csikoNumber = 0;
        this.fokaNumber = 0;
        this.selectedCountry = null;
      },
      () => {
        console.log('attacked');
        this.toastr.success('A kör végén lesz eredmény', 'Harc folyamatban!');
        this.stateChanged.emit(null);
        this.capaNumber = 0;
        this.csikoNumber = 0;
        this.fokaNumber = 0;
        this.selectedCountry = null;
        this.getTamadasInfos();
      }
    );
  }
}
