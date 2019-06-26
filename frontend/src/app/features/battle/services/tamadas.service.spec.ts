import { TestBed } from '@angular/core/testing';

import { TamadasService } from './tamadas.service';

describe('TamadasService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TamadasService = TestBed.get(TamadasService);
    expect(service).toBeTruthy();
  });
});
