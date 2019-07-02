import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { Harc } from '../../models/harc';

@Component({
  selector: 'app-fight-dialog',
  templateUrl: './fight-dialog.component.html',
  styleUrls: ['./fight-dialog.component.scss']
})
export class FightDialogComponent implements OnInit {
  constructor(@Inject(MAT_DIALOG_DATA) public data: Harc) {}

  ngOnInit() {}
}
