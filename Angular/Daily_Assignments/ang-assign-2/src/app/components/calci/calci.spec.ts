import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Calci } from './calci';

describe('Calci', () => {
  let component: Calci;
  let fixture: ComponentFixture<Calci>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Calci]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Calci);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
