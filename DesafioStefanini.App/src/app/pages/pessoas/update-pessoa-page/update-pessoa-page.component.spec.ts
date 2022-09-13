import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatePessoaPageComponent } from './update-pessoa-page.component';

describe('UpdatePessoaPageComponent', () => {
  let component: UpdatePessoaPageComponent;
  let fixture: ComponentFixture<UpdatePessoaPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdatePessoaPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdatePessoaPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
