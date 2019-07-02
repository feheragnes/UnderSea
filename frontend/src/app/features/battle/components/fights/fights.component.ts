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
          fight.capaInfoNumbers = { level1: 0, level2: 0, level3: 0 };
          fight.csikoInfoNumbers = { level1: 0, level2: 0, level3: 0 };
          fight.fokaInfoNumbers = { level1: 0, level2: 0, level3: 0 };
          fight.fokaInfo = fight.tamadoCsapat.filter(
            x => x.tipus === EgysegType.foka
          );
          fight.fokaInfo.forEach(element => {
            if (element.szint === 1) {
              fight.fokaInfoNumbers.level1 = element.mennyiseg;
            } else if (element.szint === 2) {
              fight.fokaInfoNumbers.level2 = element.mennyiseg;
            } else if (element.szint === 3) {
              fight.fokaInfoNumbers.level3 = element.mennyiseg;
            }
          });
          fight.capaInfo = fight.tamadoCsapat.filter(
            x => x.tipus === EgysegType.capa
          );
          fight.capaInfo.forEach(element => {
            if (element.szint === 1) {
              fight.capaInfoNumbers.level1 = element.mennyiseg;
            } else if (element.szint === 2) {
              fight.capaInfoNumbers.level2 = element.mennyiseg;
            } else if (element.szint === 3) {
              fight.capaInfoNumbers.level3 = element.mennyiseg;
            }
          });
          fight.csikoInfo = fight.tamadoCsapat.filter(
            x => x.tipus === EgysegType.csiko
          );
          fight.csikoInfo.forEach(element => {
            if (element.szint === 1) {
              fight.csikoInfoNumbers.level1 = element.mennyiseg;
            } else if (element.szint === 2) {
              fight.csikoInfoNumbers.level2 = element.mennyiseg;
            } else if (element.szint === 3) {
              fight.csikoInfoNumbers.level3 = element.mennyiseg;
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
