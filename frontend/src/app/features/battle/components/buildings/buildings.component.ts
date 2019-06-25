import { Component, OnInit } from "@angular/core";
import { EpuletService } from "../../services/epulet.service";
import { AuthenticationService } from "src/app/services/authentication.service";

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

  buyBuilding() {
    if (this.activeCard == "card1") {
      this.epuletService.buyEpulet("ZatonyVar").subscribe(
        data => {
          console.log(data);
        },
        error => {
          console.log(error);
        },
        () => {
          console.log("done building");
        }
      );
    }
    if (this.activeCard == "card2") {
      this.epuletService.buyEpulet("AramlasIranyito").subscribe(
        data => {
          console.log(data);
        },
        error => {
          console.log(error);
        },
        () => {
          console.log("done building");
        }
      );
    }
  }
  constructor(
    private epuletService: EpuletService,
    private readonly authService: AuthenticationService
  ) {}
  ngOnInit() {}
}
