export interface Orszag {
  id: string;
  nev: string;
  gyongy: number;
  korall: number;
  helyezes: number;
  korallTermeles: number;
  gyongyTermeles: number;
  seregInfoDTOs: [
    {
      mennyiseg: number;
      ar: number;
      tipus: string;
    }
  ];
  epuletInfoDTOs: [
    {
      tipus: string;
      ar: number;
      mennyiseg: number;
    }
  ];
}
