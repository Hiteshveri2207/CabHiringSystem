import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DriverheaderComponent } from './driverheader.component';

describe('DriverheaderComponent', () => {
  let component: DriverheaderComponent;
  let fixture: ComponentFixture<DriverheaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DriverheaderComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DriverheaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
