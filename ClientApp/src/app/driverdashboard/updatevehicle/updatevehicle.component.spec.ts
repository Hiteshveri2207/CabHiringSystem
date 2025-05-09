import { ComponentFixture, TestBed } from '@angular/core/testing';
import { UpdateVehicleComponent } from './updatevehicle.component';

describe('UpdateVehicleComponent', () => {
  let component: UpdateVehicleComponent;
  let fixture: ComponentFixture<UpdateVehicleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateVehicleComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateVehicleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
