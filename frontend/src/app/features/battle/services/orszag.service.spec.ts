import { TestBed } from '@angular/core/testing';

import { OrszagService } from './orszag.service';

describe('OrszagService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: OrszagService = TestBed.get(OrszagService);
    expect(service).toBeTruthy();
  });
});
