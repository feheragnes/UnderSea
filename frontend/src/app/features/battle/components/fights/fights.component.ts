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
        this.fights.forEach(element => {
          element.tamadoCsapat.forEach(csapat => {
            if (csapat.tipus === EgysegType.foka) {
              element.fokaInfo = csapat;
            }
            if (csapat.tipus === EgysegType.capa) {
              element.capaInfo = csapat;
            }
            if (csapat.tipus === EgysegType.csiko) {
              element.csikoInfo = csapat;
            }
          });
          switch (element.harcEredmeny) {
            case Harceredmeny.gyozelem:
              element.harcEredmeny = 'Győzelem!';
              break;
            case Harceredmeny.dontetlen:
              element.harcEredmeny = 'Döntetlen';
              break;
            case Harceredmeny.folyamatban:
              element.harcEredmeny = 'Folyamatban...';
              break;
            case Harceredmeny.vereseg:
              element.harcEredmeny = 'Vereség :(';
              break;
          }
        });
        this.fights.reverse();
      },
      err => console.error(err),
      () => {
        this.done = true;
        console.log('done loading fights');
      }
    );
  }
}
