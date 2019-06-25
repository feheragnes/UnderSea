import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-powerups',
  templateUrl: './powerups.component.html',
  styleUrls: ['./powerups.component.scss']
})
export class PowerupsComponent implements OnInit {
  colorclicked = 'rgba(255, 255, 255, 0.25)';
  color = 'transparent';
  isActive = true;
  private activeCard;
  changeColor(id) {
    console.log(id);
    document.getElementById('card1').style.backgroundColor = 'transparent';
    document.getElementById('card2').style.backgroundColor = 'transparent';
    document.getElementById('card3').style.backgroundColor = 'transparent';
    document.getElementById('card4').style.backgroundColor = 'transparent';
    document.getElementById('card5').style.backgroundColor = 'transparent';
    document.getElementById('card6').style.backgroundColor = 'transparent';
    this.activeCard = id;
    var x = document.getElementById(id);
    x.style.backgroundColor = 'rgba(255, 255, 255, 0.25)';
  }

  constructor() {}

  ngOnInit() {}
}
