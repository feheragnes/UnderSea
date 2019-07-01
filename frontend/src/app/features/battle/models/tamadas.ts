import { SeregInfo } from './orszag';

export interface TamadasInfo {
  orszag: string[];
  sereg: SeregInfo[];
}

export interface Tamadas {
  orszag: string;
  tamadoEgysegek: SeregInfo[];
}
