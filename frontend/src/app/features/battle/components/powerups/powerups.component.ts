import { Component, OnInit } from '@angular/core';
import { FejlesztesService } from '../../services/fejlesztes.service';

@Component({
  selector: 'app-powerups',
  templateUrl: './powerups.component.html',
  styleUrls: ['./powerups.component.scss']
})
export class PowerupsComponent implements OnInit {
  isActive = true;
  private activeCard;
  private fejlesztesInfo;
  traktorInfo;
  kombajnInfo;
  alkimiaInfo;
  korallInfo;
  szonarAgyuiIfo;
  vizalattiHarmuveszetInfo;

  constructor(private fejlesztesService: FejlesztesService) {}

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
        console.log(this.fejlesztesInfo);
        data.forEach(element => {
          if (element.tipus === 'IszapTraktor') {
            this.traktorInfo = element;
          }
          if (element.tipus === 'IszapKombajn') {
            this.kombajnInfo = element;
          }
          if (element.tipus === 'Alkimia') {
            this.alkimiaInfo = element;
          }
          if (element.tipus === 'KorallFal') {
            this.korallInfo = element;
          }
          if (element.tipus === 'SzonarAgyu') {
            this.szonarAgyuiIfo = element;
          }
          if (element.tipus === 'VizalattiHarmuveszet') {
            this.vizalattiHarmuveszetInfo = element;
          }
        });
      },
      err => console.error(err),
      () => {
        console.log('done loading fejlesztesInfo');
      }
    );
  }
}
