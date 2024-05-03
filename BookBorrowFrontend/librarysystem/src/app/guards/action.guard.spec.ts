import { TestBed } from '@angular/core/testing';

import { ActionGuard } from './action.guard';

describe('ActionGuard', () => {
  let guard: ActionGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(ActionGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
