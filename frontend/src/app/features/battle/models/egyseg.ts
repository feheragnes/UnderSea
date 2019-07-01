export interface Egyseg {
  tamadas: number;
  vedekezes: number;
  ar: number;
  zsold: number;
  ellatas: number;
  mennyiseg: number;
  tipus: string;
}

export enum EgysegType {
  foka = 'RohamFoka',
  capa = 'LezerCapa',
  csiko = 'CsataCsiko'
}
