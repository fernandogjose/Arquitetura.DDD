import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./pages/dashboard/dashboard.module').then(m => m.DashboardModule)
  },
  {
    path: 'anuncio-consulta',
    loadChildren: () => import('./pages/anuncio/anuncio-consulta/anuncio-consulta.module').then(m => m.AnuncioConsultaModule)
  },
  {
    path: 'anuncio-cadastro',
    loadChildren: () => import('./pages/anuncio/anuncio-cadastro/anuncio-cadastro.module').then(m => m.AnuncioCadastroModule)
  },
  {
    path: 'anuncio-cadastro/:id',
    loadChildren: () => import('./pages/anuncio/anuncio-cadastro/anuncio-cadastro.module').then(m => m.AnuncioCadastroModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
