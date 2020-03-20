import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AnuncioCadastroComponent } from './anuncio-cadastro.component';

const routes: Routes = [{
  path: '',
  component: AnuncioCadastroComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AnuncioCadastroRoutingModule { }
