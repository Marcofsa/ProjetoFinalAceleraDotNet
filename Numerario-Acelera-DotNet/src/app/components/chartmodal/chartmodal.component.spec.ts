import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChartmodalComponent } from './chartmodal.component';

describe('ChartmodalComponent', () => {
  let component: ChartmodalComponent;
  let fixture: ComponentFixture<ChartmodalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ChartmodalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChartmodalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
