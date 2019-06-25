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
      },
      err => console.error(err),
      () => {
        console.log('done loading fejlesztesInfo');
      }
    );
  }
}
