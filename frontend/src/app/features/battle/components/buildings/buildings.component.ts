import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-buildings",
  templateUrl: "./buildings.component.html",
  styleUrls: ["./buildings.component.scss"]
})
export class BuildingsComponent implements OnInit {
  colorclicked = "rgba(255, 255, 255, 0.25)";
  color = "transparent";
  isActive = true;
  activeCard;
  changeColor(id) {
    document.getElementById("card1").style.backgroundColor = "transparent";
    document.getElementById("card2").style.backgroundColor = "transparent";
    this.activeCard = id;
    var x = document.getElementById(id);
    x.style.backgroundColor = "rgba(255, 255, 255, 0.25)";
  }
  constructor() {}
  ngOnInit() {}
}