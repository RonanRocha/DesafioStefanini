import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Cidade } from 'src/app/models/cidade.model';
import { CidadeService } from 'src/app/services/cidade.service';

@Component({
  selector: 'app-show-cidade-page',
  templateUrl: './show-cidade-page.component.html',
  styleUrls: ['./show-cidade-page.component.scss']
})
export class ShowCidadePageComponent implements OnInit {

  id: any;
  cidade: Cidade = {} as Cidade;

  constructor(private cidadeService: CidadeService, private route: ActivatedRoute) {
    this.id = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {

    this.Load();
  }

  Load() {
    return this.cidadeService.getCity(this.id).subscribe((data) => {
      this.cidade = data.data;
    })
  }

}
