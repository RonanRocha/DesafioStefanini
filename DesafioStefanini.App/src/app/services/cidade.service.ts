import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CidadeService {

  constructor(private http: HttpClient) { }

  public url = 'http://localhost:5000/api/cidade';

  public getCities() {
    return this.http.get<any>(this.url);
  }
}
