import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pessoa } from '../models/pessoa.model';

@Injectable({
  providedIn: 'root'
})
export class PessoaService {

  constructor(private http: HttpClient) { }

  public url = 'http://localhost:5000/api/pessoa';


  public getPessoas() {
    return this.http.get<any>(this.url);
  }

  public getPessoa(id: any) {
    return this.http.get<any>(this.url + '/' + id);
  }

  public createPessoa(cidade: Pessoa) {
    return this.http.post(this.url, cidade);
  }

  public updatePessoa(id: any, cidade: Pessoa) {
    return this.http.put(this.url + "/" + id, cidade)
  }

  public removePessoa(id: any) {
    return this.http.delete(this.url + "/" + id);
  }
}
