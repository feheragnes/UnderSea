import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { TamadasService } from '../../services/tamadas.service';
import { Army } from '../../models/army';
import { Fight } from '../../models/fight';
import { EgysegType } from '../../models/egyseg';

@Component({
  selector: 'app-fights',
  templateUrl: './fights.component.html',
  styleUrls: ['./fights.component.scss']
})
export class FightsComponent implements OnInit {
  @Output() stateChanged = new EventEmitter();
  public fights: Array<Fight>;
  public done = false;

  constructor(private tamadasService: TamadasService) {}

  ngOnInit() {
    this.getHarcStatusz();
    this.fights = new Array<Fight>();
  }

  getHarcStatusz() {
    this.tamadasService.getHarcStatusz().subscribe(
      data => {
        data.forEach(element => {
          let capaNumber = 0;
          let csikoNumber = 0;
          let fokaNumber = 0;
          element.tamadoCsapat.forEach(csapat => {
            if (csapat.tipus === EgysegType.foka) {
              fokaNumber = csapat.mennyiseg;
            }
            if (csapat.tipus === EgysegType.capa) {
              capaNumber = csapat.mennyiseg;
            }
            if (csapat.tipus === EgysegType.csiko) {
              csikoNumber = csapat.mennyiseg;
            }
          });
          const army = new Army(capaNumber, csikoNumber, fokaNumber);
          console.log(army);
          this.fights.push(
            new Fight(element.vedekezoOrszag, element.harcEredmeny, army)
          );
        });
        console.log(this.fights);
      },
      err => console.error(err),
      () => {
        this.done = true;
        console.log('done loading fights');
      }
    );
  }
}
