export interface Fejlesztes {
  tipus: string;
  kifejlesztve?: boolean;
  aktualisKor?: number;
}

export enum FejlesztesType {
  traktor = 'IszapTraktor',
  kombajn = 'IszapKombajn',
  alkimia = 'Alkimia',
  korall = 'KorallFal',
  szonarAgyu = 'SzonarAgyu',
  vizalatti = 'VizalattiHarcmuveszet'
}
