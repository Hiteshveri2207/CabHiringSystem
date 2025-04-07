import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DriverfooterComponent } from './driverfooter.component';

describe('DriverfooterComponent', () => {
  let component: DriverfooterComponent;
  let fixture: ComponentFixture<DriverfooterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DriverfooterComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DriverfooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
