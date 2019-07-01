export interface Orszag {
  id: string;
  nev: string;
  gyongy: number;
  korall: number;
  helyezes: number;
  korallTermeles: number;
  gyongyTermeles: number;
  seregInfo: SeregInfo[];
  epuletInfo: EpuletInfo[];
  epuloAramlasIranyito: number;
  epuloZatonyvar: number;
}

export interface SeregInfo {
  mennyiseg: number;
  ar?: number;
  tipus: string;
}

export interface EpuletInfo {
  tipus: string;
  ar: number;
  mennyiseg: number;
}
