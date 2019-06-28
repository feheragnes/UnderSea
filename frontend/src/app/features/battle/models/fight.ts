import { Army } from './army';

export class Fight {
  constructor(
    public vedekezoOrszag: string,
    public harcEredmeny: string,
    public army: Army
  ) {}
}
