import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Cidade } from 'src/app/models/cidade.model';
import { CidadeService } from 'src/app/services/cidade.service';

@Component({
  selector: 'app-create-cidade-page',
  templateUrl: './create-cidade-page.component.html',
  styleUrls: ['./create-cidade-page.component.scss']
})
export class CreateCidadePageComponent implements OnInit {

  form!: FormGroup

  constructor(private cidadeService: CidadeService) { }

  ngOnInit(): void {

    this.form = new FormGroup({
      nome: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(200)]),
      uf: new FormControl('', [Validators.maxLength(2), Validators.required, Validators.minLength(2)])
    });
  }


  Salvar() {
    console.log(this.form.value);
    this.cidadeService.createCity(this.form.value as Cidade).subscribe((data) => {
      console.log(data);
    });
  }

}
