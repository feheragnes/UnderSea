import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-army",
  templateUrl: "./army.component.html",
  styleUrls: ["./army.component.scss"]
})
export class ArmyComponent implements OnInit {
  private capaNumber = 0;
  private fokaNumber = 0;
  private csikoNumber = 0;

  changeNumber(type: string, value: number) {
    switch (type) {
      case "csiko":
        this.csikoNumber += value;
        if (this.csikoNumber < 0) this.csikoNumber = 0;
        break;
      case "foka":
        this.fokaNumber += value;
        if (this.fokaNumber < 0) this.fokaNumber = 0;
        break;
      case "capa":
        this.capaNumber += value;
        if (this.capaNumber < 0) this.capaNumber = 0;
        break;
    }
    console.log(type, value);
  }

  constructor() {}

  ngOnInit() {}
}
