import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CidadeService } from 'src/app/services/cidade.service';

@Component({
  selector: 'app-list-cidade-page',
  templateUrl: './list-cidade-page.component.html',
  styleUrls: ['./list-cidade-page.component.scss']
})
export class ListCidadePageComponent implements OnInit {

  public data!: Observable<any>;

  constructor(private cidadeService: CidadeService) { }

  ngOnInit(): void {

    this.cidadeService.getCities().subscribe((data) => {
      this.data = data;
    });
  }

}
