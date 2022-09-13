import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Cidade } from 'src/app/models/cidade.model';
import { Pessoa } from 'src/app/models/pessoa.model';
import { CidadeService } from 'src/app/services/cidade.service';
import { PessoaService } from 'src/app/services/pessoa.service';

@Component({
  selector: 'app-create-pessoa-page',
  templateUrl: './create-pessoa-page.component.html',
  styleUrls: ['./create-pessoa-page.component.scss']
})
export class CreatePessoaPageComponent implements OnInit {

  form!: FormGroup
  cidades: Cidade[] = [];

  constructor(private pessoaService: PessoaService, private cidadeService: CidadeService) { }

  ngOnInit(): void {

    this.LoadCidades();

    this.form = new FormGroup({
      nome: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(200)]),
      cpf: new FormControl('', [Validators.required, Validators.minLength(11)]),
      idade: new FormControl('', [Validators.required]),
      id_cidade: new FormControl('', [Validators.required])
    });
  }

  LoadCidades() {
    this.cidadeService.getCities().subscribe((data) => {
      this.cidades = data.data;
    });
  }


  Salvar() {

    this.pessoaService.createPessoa(this.form.value as Pessoa).subscribe((data) => {
      console.log(data);
    });
  }
}
