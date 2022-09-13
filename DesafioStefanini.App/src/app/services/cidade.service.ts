import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cidade } from '../models/cidade.model';

@Injectable({
  providedIn: 'root'
})
export class CidadeService {

  constructor(private http: HttpClient) { }

  public url = 'http://localhost:5000/api/cidade';


  public getCities() {
    return this.http.get<any>(this.url);
  }

  public getCity(id: any) {
    return this.http.get<any>(this.url + '/' + id);
  }

  public createCity(cidade: Cidade) {
    return this.http.post(this.url, cidade);
  }

  public updateCity(id: any, cidade: Cidade) {
    return this.http.put(this.url + "/" + id, cidade)
  }

  public removeCity(id: any) {
    return this.http.delete(this.url + "/" + id);
  }

}
