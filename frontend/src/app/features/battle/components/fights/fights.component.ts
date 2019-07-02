import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { TamadasService } from '../../services/tamadas.service';
import { Harceredmeny, Harc } from '../../models/harc';
import { EgysegType } from '../../models/egyseg';
import { FightDialogComponent } from '../fight-dialog/fight-dialog.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-fights',
  templateUrl: './fights.component.html',
  styleUrls: ['./fights.component.scss']
})
export class FightsComponent implements OnInit {
  @Output() stateChanged = new EventEmitter();
  public fights: Harc[];
  public done = false;

  constructor(
    private tamadasService: TamadasService,
    public dialog: MatDialog
  ) {}

  ngOnInit() {
    this.getHarcStatusz();
  }

  openDialog(fight: Harc) {
    console.log('dialog');
    this.dialog.open(FightDialogComponent, {
      data: fight
    });
  }

  getHarcStatusz() {
    this.tamadasService.getHarcStatusz().subscribe(
      data => {
        this.fights = data;
        console.log(this.fights);
        this.fights.forEach(fight => {
          fight.capaInfoTamadoNumbers = { level1: 0, level2: 0, level3: 0 };
          fight.csikoInfoTamadoNumbers = { level1: 0, level2: 0, level3: 0 };
          fight.fokaInfoTamadoNumbers = { level1: 0, level2: 0, level3: 0 };
          fight.capaInfoVedoNumbers = { level1: 0, level2: 0, level3: 0 };
          fight.csikoInfoVedoNumbers = { level1: 0, level2: 0, level3: 0 };
          fight.fokaInfoVedoNumbers = { level1: 0, level2: 0, level3: 0 };
          fight.tamadoCsapat
            .filter(x => x.tipus === EgysegType.foka)
            .forEach(element => {
              if (element.szint === 1) {
                fight.fokaInfoTamadoNumbers.level1 = element.mennyiseg;
              } else if (element.szint === 2) {
                fight.fokaInfoTamadoNumbers.level2 = element.mennyiseg;
              } else if (element.szint === 3) {
                fight.fokaInfoTamadoNumbers.level3 = element.mennyiseg;
              }
            });
          fight.tamadoCsapat
            .filter(x => x.tipus === EgysegType.capa)
            .forEach(element => {
              if (element.szint === 1) {
                fight.capaInfoTamadoNumbers.level1 = element.mennyiseg;
              } else if (element.szint === 2) {
                fight.capaInfoTamadoNumbers.level2 = element.mennyiseg;
              } else if (element.szint === 3) {
                fight.capaInfoTamadoNumbers.level3 = element.mennyiseg;
              }
            });
          fight.tamadoCsapat
            .filter(x => x.tipus === EgysegType.csiko)
            .forEach(element => {
              if (element.szint === 1) {
                fight.csikoInfoTamadoNumbers.level1 = element.mennyiseg;
              } else if (element.szint === 2) {
                fight.csikoInfoTamadoNumbers.level2 = element.mennyiseg;
              } else if (element.szint === 3) {
                fight.csikoInfoTamadoNumbers.level3 = element.mennyiseg;
              }
            });

          fight.vedekezoCsapat
            .filter(x => x.tipus === EgysegType.foka)
            .forEach(element => {
              if (element.szint === 1) {
                fight.fokaInfoVedoNumbers.level1 = element.mennyiseg;
              } else if (element.szint === 2) {
                fight.fokaInfoVedoNumbers.level2 = element.mennyiseg;
              } else if (element.szint === 3) {
                fight.fokaInfoVedoNumbers.level3 = element.mennyiseg;
              }
            });
          fight.vedekezoCsapat
            .filter(x => x.tipus === EgysegType.capa)
            .forEach(element => {
              if (element.szint === 1) {
                fight.capaInfoVedoNumbers.level1 = element.mennyiseg;
              } else if (element.szint === 2) {
                fight.capaInfoVedoNumbers.level2 = element.mennyiseg;
              } else if (element.szint === 3) {
                fight.capaInfoVedoNumbers.level3 = element.mennyiseg;
              }
            });
          fight.vedekezoCsapat
            .filter(x => x.tipus === EgysegType.csiko)
            .forEach(element => {
              if (element.szint === 1) {
                fight.csikoInfoVedoNumbers.level1 = element.mennyiseg;
              } else if (element.szint === 2) {
                fight.csikoInfoVedoNumbers.level2 = element.mennyiseg;
              } else if (element.szint === 3) {
                fight.csikoInfoVedoNumbers.level3 = element.mennyiseg;
              }
            });

          switch (fight.harcEredmeny) {
            case Harceredmeny.gyozelem:
              fight.harcEredmeny = 'Győzelem!';
              break;
            case Harceredmeny.dontetlen:
              fight.harcEredmeny = 'Döntetlen';
              break;
            case Harceredmeny.folyamatban:
              fight.harcEredmeny = 'Folyamatban...';
              break;
            case Harceredmeny.vereseg:
              fight.harcEredmeny = 'Vereség :(';
              break;
          }
        });
        this.fights.reverse();
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
