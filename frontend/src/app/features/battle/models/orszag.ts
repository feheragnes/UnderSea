export interface Orszag {
  id: string;
  nev: string;
  gyongy: number;
  korall: number;
  helyezes: number;
  korallTermeles: number;
  gyongyTermeles: number;
  seregInfo: [
    {
      mennyiseg: number;
      ar: number;
      tipus: string;
    }
  ];
  epuletInfo: [
    {
      tipus: string;
      ar: number;
      mennyiseg: number;
    }
  ];
}
