import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CreatePessoaPageComponent } from './pages/pessoas/create-pessoa-page/create-pessoa-page.component';
import { UpdatePessoaPageComponent } from './pages/pessoas/update-pessoa-page/update-pessoa-page.component';
import { ShowPessoaPageComponent } from './pages/pessoas/show-pessoa-page/show-pessoa-page.component';
import { ListPessoaPageComponent } from './pages/pessoas/list-pessoa-page/list-pessoa-page.component';
import { ListCidadePageComponent } from './pages/cidades/list-cidade-page/list-cidade-page.component';
import { ShowCidadePageComponent } from './pages/cidades/show-cidade-page/show-cidade-page.component';
import { UpdateCidadePageComponent } from './pages/cidades/update-cidade-page/update-cidade-page.component';
import { CreateCidadePageComponent } from './pages/cidades/create-cidade-page/create-cidade-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CreatePessoaPageComponent,
    UpdatePessoaPageComponent,
    ShowPessoaPageComponent,
    ListPessoaPageComponent,
    ListCidadePageComponent,
    ShowCidadePageComponent,
    UpdateCidadePageComponent,
    CreateCidadePageComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
