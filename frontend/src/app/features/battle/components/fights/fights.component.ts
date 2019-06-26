import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-fights',
  templateUrl: './fights.component.html',
  styleUrls: ['./fights.component.scss']
})
export class FightsComponent implements OnInit {
  @Output() stateChanged = new EventEmitter();
  constructor() {}

  ngOnInit() {}
}
