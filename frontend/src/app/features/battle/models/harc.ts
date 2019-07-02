import { SeregInfo } from './orszag';
import { LevelNumbers } from './levelNumbers';

export interface Harc {
  vedekezoOrszag: string;
  tamadoOrszag: string;
  harcEredmeny: string;
  tamadoCsapat: SeregInfo[];
  vedekezoCsapat: SeregInfo[];
  csikoInfo?: SeregInfo[];
  capaInfo?: SeregInfo[];
  fokaInfo?: SeregInfo[];
  csikoInfoVedoNumbers: LevelNumbers;
  capaInfoVedoNumbers: LevelNumbers;
  fokaInfoVedoNumbers: LevelNumbers;
  csikoInfoTamadoNumbers: LevelNumbers;
  capaInfoTamadoNumbers: LevelNumbers;
  fokaInfoTamadoNumbers: LevelNumbers;
  raboltGyongy: number;
  raboltKorall: number;
}

export enum Harceredmeny {
  gyozelem = 'Gyozelem',
  vereseg = 'Vereseg',
  folyamatban = 'Folyamatban',
  dontetlen = 'Dontetlen'
}
