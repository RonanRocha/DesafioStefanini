import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Cidade } from 'src/app/models/cidade.model';
import { CidadeService } from 'src/app/services/cidade.service';
import { PessoaService } from 'src/app/services/pessoa.service';

@Component({
  selector: 'app-update-pessoa-page',
  templateUrl: './update-pessoa-page.component.html',
  styleUrls: ['./update-pessoa-page.component.scss']
})
export class UpdatePessoaPageComponent implements OnInit {

  form: FormGroup = new FormGroup({
    nome: new FormControl(''),
    cpf: new FormControl(''),
    idade: new FormControl(''),
    id_cidade: new FormControl('')
  });

  id: any;
  cidades: Cidade[] = [];

  constructor(private cidadeService: CidadeService,
    private pessoaService: PessoaService,
    private route: ActivatedRoute) {
    this.id = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {
    this.LoadCidades();

  }


  LoadCidades() {
    this.cidadeService.getCities().subscribe((data) => {
      this.cidades = data.data;
      this.Load();
    });
  }

  Load() {

    this.pessoaService.getPessoa(this.id).subscribe((data) => {
      const response = data.data as any;

      this.form = new FormGroup({
        nome: new FormControl(response.nome, [Validators.required, Validators.minLength(3), Validators.maxLength(200)]),
        cpf: new FormControl(response.cpf, [Validators.required, Validators.minLength(11)]),
        idade: new FormControl(response.idade, [Validators.required]),
        id_cidade: new FormControl(response.cidade.id, [Validators.required]),
      });
    })


  }

  Atualizar() {
    this.pessoaService.updatePessoa(this.id, this.form.value).subscribe((data) => {
      const response = data as any;
    })
  }

}
