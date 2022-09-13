import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePessoaPageComponent } from './create-pessoa-page.component';

describe('CreatePessoaPageComponent', () => {
  let component: CreatePessoaPageComponent;
  let fixture: ComponentFixture<CreatePessoaPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreatePessoaPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatePessoaPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
