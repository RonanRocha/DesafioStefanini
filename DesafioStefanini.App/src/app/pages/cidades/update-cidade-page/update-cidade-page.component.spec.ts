import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateCidadePageComponent } from './update-cidade-page.component';

describe('UpdateCidadePageComponent', () => {
  let component: UpdateCidadePageComponent;
  let fixture: ComponentFixture<UpdateCidadePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateCidadePageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateCidadePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
