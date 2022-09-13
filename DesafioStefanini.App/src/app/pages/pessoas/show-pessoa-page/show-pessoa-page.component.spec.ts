import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowPessoaPageComponent } from './show-pessoa-page.component';

describe('ShowPessoaPageComponent', () => {
  let component: ShowPessoaPageComponent;
  let fixture: ComponentFixture<ShowPessoaPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowPessoaPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowPessoaPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
