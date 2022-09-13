import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListCidadePageComponent } from './list-cidade-page.component';

describe('ListCidadePageComponent', () => {
  let component: ListCidadePageComponent;
  let fixture: ComponentFixture<ListCidadePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListCidadePageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListCidadePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
