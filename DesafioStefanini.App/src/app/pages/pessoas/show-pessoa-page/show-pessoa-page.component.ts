import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Pessoa } from 'src/app/models/pessoa.model';
import { PessoaService } from 'src/app/services/pessoa.service';

@Component({
  selector: 'app-show-pessoa-page',
  templateUrl: './show-pessoa-page.component.html',
  styleUrls: ['./show-pessoa-page.component.scss']
})
export class ShowPessoaPageComponent implements OnInit {

  id: any;
  pessoa: Pessoa = {} as Pessoa;

  constructor(private pessoaService: PessoaService, private route: ActivatedRoute) {
    this.id = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {

    this.Load();
  }

  Load() {
    return this.pessoaService.getPessoa(this.id).subscribe((data) => {
      this.pessoa = data.data;
    })
  }

}
