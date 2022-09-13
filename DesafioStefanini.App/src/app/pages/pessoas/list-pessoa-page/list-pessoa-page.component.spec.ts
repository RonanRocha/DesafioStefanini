import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListPessoaPageComponent } from './list-pessoa-page.component';

describe('ListPessoaPageComponent', () => {
  let component: ListPessoaPageComponent;
  let fixture: ComponentFixture<ListPessoaPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListPessoaPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListPessoaPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
