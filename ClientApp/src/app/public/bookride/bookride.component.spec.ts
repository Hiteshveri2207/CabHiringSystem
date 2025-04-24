import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookRideComponent } from './bookride.component';

describe('BookRideComponent', () => {
  let component: BookRideComponent;
  let fixture: ComponentFixture<BookRideComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BookRideComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookRideComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
