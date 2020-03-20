import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AnuncioConsultaComponent } from './anuncio-consulta.component';

const routes: Routes = [{
  path: '',
  component: AnuncioConsultaComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AnuncioConsultaRoutingModule { }
