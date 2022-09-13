import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateCidadePageComponent } from './create-cidade-page.component';

describe('CreateCidadePageComponent', () => {
  let component: CreateCidadePageComponent;
  let fixture: ComponentFixture<CreateCidadePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateCidadePageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateCidadePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
