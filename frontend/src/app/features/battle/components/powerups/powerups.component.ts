import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FejlesztesService } from '../../services/fejlesztes.service';
import { ToastrService } from 'ngx-toastr';
import { Fejlesztes, FejlesztesType } from '../../models/fejlesztes';

@Component({
  selector: 'app-powerups',
  templateUrl: './powerups.component.html',
  styleUrls: ['./powerups.component.scss']
})
export class PowerupsComponent implements OnInit {
  public activeCard: string;
  public fejlesztesInfo: Fejlesztes[];
  public traktorInfo: Fejlesztes;
  public kombajnInfo: Fejlesztes;
  public alkimiaInfo: Fejlesztes;
  public korallInfo: Fejlesztes;
  public szonarAgyuInfo: Fejlesztes;
  public vizalattiHarcmuveszetInfo: Fejlesztes;
  public isDisabled: boolean;
  @Output() stateChanged = new EventEmitter();

  constructor(
    private fejlesztesService: FejlesztesService,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.getFejlesztesInfos();
  }

  setActive(id: string) {
    this.activeCard = id;
  }

  getFejlesztesInfos() {
    this.fejlesztesService.getFejlesztesInfo().subscribe(
      data => {
        this.fejlesztesInfo = data;
        data.forEach(element => {
          if (element.tipus === FejlesztesType.traktor) {
            this.traktorInfo = element;
          }
          if (element.tipus === FejlesztesType.kombajn) {
            this.kombajnInfo = element;
          }
          if (element.tipus === FejlesztesType.alkimia) {
            this.alkimiaInfo = element;
          }
          if (element.tipus === FejlesztesType.korall) {
            this.korallInfo = element;
          }
          if (element.tipus === FejlesztesType.szonarAgyu) {
            this.szonarAgyuInfo = element;
          }
          if (element.tipus === FejlesztesType.vizalatti) {
            this.vizalattiHarcmuveszetInfo = element;
          }
        });
      },
      err => console.error(err),
      () => {
        console.log('done loading fejlesztesInfo');
      }
    );
  }

  buyFejlesztes() {
    let type;
    switch (this.activeCard) {
      case 'traktor':
        type = FejlesztesType.traktor;
        break;
      case 'kombajn':
        type = FejlesztesType.kombajn;
        break;
      case 'korallfal':
        type = FejlesztesType.korall;
        break;
      case 'szonaragyu':
        type = FejlesztesType.szonarAgyu;
        break;
      case 'vizalatti':
        type = FejlesztesType.vizalatti;
        break;
      case 'alkimia':
        type = FejlesztesType.alkimia;
        break;
    }
    this.fejlesztesService.buyFejlesztes(type).subscribe(
      data => {
        console.log(data);
      },
      error => {
        this.toastr.error(error, 'Nem sikerült fejleszteni :(');
        console.log(error);
      },
      () => {
        this.toastr.success('15 kör múlva elkészül', 'Fejlesztés folyamatban!');
        this.getFejlesztesInfos();
      }
    );
  }
}
