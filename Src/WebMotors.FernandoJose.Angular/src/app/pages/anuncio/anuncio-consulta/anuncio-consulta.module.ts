import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { library } from '@fortawesome/fontawesome-svg-core';
import { fas } from '@fortawesome/free-solid-svg-icons';
import { ReactiveFormsModule } from '@angular/forms';
import { PaginationModule } from 'ngx-bootstrap';
import { AnuncioService } from '../../../services/pages/anuncio.service';
import { AnuncioConsultaComponent } from './anuncio-consulta.component';
import { AnuncioConsultaRoutingModule } from './anuncio-consulta-routing.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

library.add(fas);

@NgModule({
  declarations: [
    AnuncioConsultaComponent
  ],
  imports: [
    CommonModule,
    AnuncioConsultaRoutingModule,
    FontAwesomeModule,
    ReactiveFormsModule,
    PaginationModule.forRoot()
  ],
  providers: [
    AnuncioService
  ],
  exports: [
    AnuncioConsultaComponent
  ]
})
export class AnuncioConsultaModule { }
