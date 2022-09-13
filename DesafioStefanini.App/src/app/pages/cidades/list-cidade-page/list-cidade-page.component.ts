import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Cidade } from 'src/app/models/cidade.model';
import { CidadeService } from 'src/app/services/cidade.service';

@Component({
  selector: 'app-list-cidade-page',
  templateUrl: './list-cidade-page.component.html',
  styleUrls: ['./list-cidade-page.component.scss']
})
export class ListCidadePageComponent implements OnInit {

  public cidades: Cidade[] = [];

  constructor(private cidadeService: CidadeService) { }

  ngOnInit(): void {
    this.Load();
  }

  Load() {
    this.cidadeService.getCities().subscribe((data) => {
      this.cidades = data.data;
    });
  }


  Remover(id: number) {

    if (confirm("Deseja realmente excluir o registro")) {

      this.cidadeService.removeCity(id).subscribe((data) => {
        const isSuccess = data as any;
        if (isSuccess.succeeded) {
          this.Load()
        }
      });
    }
  }

}
