import { SeregInfo } from './orszag';

export interface Harc {
  vedekezoOrszag: string;
  harcEredmeny: string;
  tamadoCsapat: SeregInfo[];
  csikoInfo?: SeregInfo;
  capaInfo?: SeregInfo;
  fokaInfo?: SeregInfo;
}

export enum Harceredmeny {
  gyozelem = 'Gyozelem',
  vereseg = 'Vereseg',
  folyamatban = 'Folyamatban',
  dontetlen = 'Dontetlen'
}
