import { Component, OnInit } from '@angular/core';
import { TamadasService } from '../../services/tamadas.service';

@Component({
  selector: 'app-attack',
  templateUrl: './attack.component.html',
  styleUrls: ['./attack.component.scss']
})
export class AttackComponent implements OnInit {
  capaNumber = 0;
  private fokaNumber = 0;
  private csikoNumber = 0;
  private tamadasInfo;
  private countries;
  private filteredCountries;
  private selectedCountry;
  fokaInfo;
  capaInfo;
  csikoInfo;

  constructor(private tamadasService: TamadasService) {}

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
        console.log(this.tamadasInfo);
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
}
