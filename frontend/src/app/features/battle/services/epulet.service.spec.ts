import { TestBed } from '@angular/core/testing';

import { EpuletService } from './epulet.service';

describe('EpuletService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EpuletService = TestBed.get(EpuletService);
    expect(service).toBeTruthy();
  });
});
