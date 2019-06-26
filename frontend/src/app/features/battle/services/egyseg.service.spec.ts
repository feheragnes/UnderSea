import { TestBed } from '@angular/core/testing';

import { EgysegService } from './egyseg.service';

describe('EgysegService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EgysegService = TestBed.get(EgysegService);
    expect(service).toBeTruthy();
  });
});
