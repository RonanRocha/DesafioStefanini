import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateCidadePageComponent } from './pages/cidades/create-cidade-page/create-cidade-page.component';
import { ListCidadePageComponent } from './pages/cidades/list-cidade-page/list-cidade-page.component';
import { ShowCidadePageComponent } from './pages/cidades/show-cidade-page/show-cidade-page.component';
import { UpdateCidadePageComponent } from './pages/cidades/update-cidade-page/update-cidade-page.component';
import { CreatePessoaPageComponent } from './pages/pessoas/create-pessoa-page/create-pessoa-page.component';
import { ListPessoaPageComponent } from './pages/pessoas/list-pessoa-page/list-pessoa-page.component';
import { ShowPessoaPageComponent } from './pages/pessoas/show-pessoa-page/show-pessoa-page.component';
import { UpdatePessoaPageComponent } from './pages/pessoas/update-pessoa-page/update-pessoa-page.component';

const routes: Routes = [
  { path: '', component: ListCidadePageComponent },
  { path: 'cidades', component: ListCidadePageComponent },
  { path: 'cidades/:id/show', component: ShowCidadePageComponent },
  { path: 'cidades/:id/edit', component: UpdateCidadePageComponent },
  { path: 'cidades/create', component: CreateCidadePageComponent },
  { path: 'pessoas', component: ListPessoaPageComponent },
  { path: 'pessoas/:id/show', component: ShowPessoaPageComponent },
  { path: 'pessoas/:id/edit', component: UpdatePessoaPageComponent },
  { path: 'pessoas/create', component: CreatePessoaPageComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
