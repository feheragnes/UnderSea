import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { TamadasService } from '../../services/tamadas.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-attack',
  templateUrl: './attack.component.html',
  styleUrls: ['./attack.component.scss']
})
export class AttackComponent implements OnInit {
  public capaNumber = 0;
  public fokaNumber = 0;
  public csikoNumber = 0;
  public tamadasInfo;
  public countries;
  public filteredCountries;
  public selectedCountry;
  public fokaInfo;
  public capaInfo;
  public csikoInfo;
  @Output() stateChanged = new EventEmitter();

  constructor(
    private tamadasService: TamadasService,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.getTamadasInfos();
  }

  getTamadasInfos() {
    this.tamadasService.getTamadasInfo().subscribe(
      data => {
        this.tamadasInfo = data;
        this.countries = data.orszag;
        this.filteredCountries = data.orszag;
        data.sereg.forEach(element => {
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
      ]
    };

    this.tamadasService.tamadas(parameter).subscribe(
      data => {
        console.log(data);
      },
      error => {
        this.toastr.error(error, 'Nem sikerült támadni :(');
        console.log(error);
        this.capaNumber = 0;
        this.csikoNumber = 0;
        this.fokaNumber = 0;
        this.selectedCountry = null;
      },
      () => {
        this.stateChanged.emit(null);
        this.toastr.success('A kör végén lesz eredmény', 'Harc folyamatban!');
        this.getTamadasInfos();
        this.capaNumber = 0;
        this.csikoNumber = 0;
        this.fokaNumber = 0;
        this.selectedCountry = null;
      }
    );
  }
}
