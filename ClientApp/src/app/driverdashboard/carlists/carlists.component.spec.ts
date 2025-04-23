import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CarlistsComponent } from './carlists.component';

describe('CarlistsComponent', () => {
  let component: CarlistsComponent;
  let fixture: ComponentFixture<CarlistsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarlistsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarlistsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
