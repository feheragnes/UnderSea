import { Component, OnInit } from '@angular/core';
import { EpuletService } from '../../services/epulet.service';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-buildings',
  templateUrl: './buildings.component.html',
  styleUrls: ['./buildings.component.scss']
})
export class BuildingsComponent implements OnInit {
  private activeCard;
  private epuletInfo;

  constructor(private epuletService: EpuletService) {}
  ngOnInit() {
    this.getEpuletInfo();
  }

  setActive(id: string) {
    this.activeCard = id;
  }

  getEpuletInfo() {
    this.epuletService.getEpuletInfo().subscribe(
      data => {
        this.epuletInfo = data;
        console.log(this.epuletInfo);
      },
      err => console.error(err),
      () => {
        console.log('done loading epuletInfo');
      }
    );
  }

  buyBuilding() {
    let type;
    if (this.activeCard === 'card1') {
      type = 'ZatonyVar';
    }
    if (this.activeCard === 'card2') {
      type = 'AramlasIranyito';
    }
    this.epuletService.buyEpulet(type).subscribe(
      data => {
        console.log(data);
      },
      error => {
        console.log(error);
      },
      () => {
        console.log('done building');
      }
    );
  }
}
