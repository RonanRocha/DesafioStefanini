import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CidadeService } from 'src/app/services/cidade.service';

@Component({
  selector: 'app-update-cidade-page',
  templateUrl: './update-cidade-page.component.html',
  styleUrls: ['./update-cidade-page.component.scss']
})
export class UpdateCidadePageComponent implements OnInit {

  form: FormGroup = new FormGroup({
    nome: new FormControl(''),
    uf: new FormControl('')
  });

  id: any;

  constructor(private cidadeService: CidadeService, private route: ActivatedRoute) {
    this.id = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {

    this.Load();
  }


  Load() {

    this.cidadeService.getCity(this.id).subscribe((data) => {
      const response = data.data as any;

      this.form = new FormGroup({
        nome: new FormControl(response.nome, [Validators.required, Validators.minLength(3), Validators.maxLength(200)]),
        uf: new FormControl(response.uf, [Validators.maxLength(2), Validators.required, Validators.minLength(2)])
      });
    })


  }

  Atualizar() {
    this.cidadeService.updateCity(this.id, this.form.value).subscribe((data) => {
      const response = data as any;
    })
  }

}
