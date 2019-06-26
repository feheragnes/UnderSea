import { TestBed } from '@angular/core/testing';

import { FejlesztesService } from './fejlesztes.service';

describe('FejlesztesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FejlesztesService = TestBed.get(FejlesztesService);
    expect(service).toBeTruthy();
  });
});
