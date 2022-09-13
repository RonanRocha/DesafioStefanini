import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowCidadePageComponent } from './show-cidade-page.component';

describe('ShowCidadePageComponent', () => {
  let component: ShowCidadePageComponent;
  let fixture: ComponentFixture<ShowCidadePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowCidadePageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowCidadePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
