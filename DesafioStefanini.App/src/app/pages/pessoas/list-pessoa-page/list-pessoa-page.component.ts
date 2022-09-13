import { Component, OnInit } from '@angular/core';
import { Pessoa } from 'src/app/models/pessoa.model';
import { PessoaService } from 'src/app/services/pessoa.service';

@Component({
  selector: 'app-list-pessoa-page',
  templateUrl: './list-pessoa-page.component.html',
  styleUrls: ['./list-pessoa-page.component.scss']
})
export class ListPessoaPageComponent implements OnInit {

  pessoas: Pessoa[] = [];

  constructor(private pessoaService: PessoaService) { }

  ngOnInit(): void {
    this.Load();
  }

  Load() {
    this.pessoaService.getPessoas().subscribe((data) => {
      this.pessoas = data.data;
    });
  }


  Remover(id: number) {

    if (confirm("Deseja realmente excluir o registro")) {

      this.pessoaService.removePessoa(id).subscribe((data) => {
        const isSuccess = data as any;
        if (isSuccess.succeeded) {
          this.Load()
        }
      });
    }
  }

}
