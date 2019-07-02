import { SeregInfo } from './orszag';
import { LevelNumbers } from './levelNumbers';

export interface Harc {
  vedekezoOrszag: string;
  harcEredmeny: string;
  tamadoCsapat: SeregInfo[];
  csikoInfo?: SeregInfo[];
  capaInfo?: SeregInfo[];
  fokaInfo?: SeregInfo[];
  csikoInfoNumbers: LevelNumbers;
  capaInfoNumbers: LevelNumbers;
  fokaInfoNumbers: LevelNumbers;
}

export enum Harceredmeny {
  gyozelem = 'Gyozelem',
  vereseg = 'Vereseg',
  folyamatban = 'Folyamatban',
  dontetlen = 'Dontetlen'
}
