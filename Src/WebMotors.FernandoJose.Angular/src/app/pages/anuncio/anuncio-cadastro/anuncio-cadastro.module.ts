import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxMaskModule } from 'ngx-mask';
import { AnuncioService } from 'src/app/services/pages/anuncio.service';
import { AnuncioCadastroRoutingModule } from './anuncio-cadastro-routing.module';
import { AnuncioCadastroComponent } from './anuncio-cadastro.component';

@NgModule({
  declarations: [
    AnuncioCadastroComponent
  ],
  imports: [
    CommonModule,
    AnuncioCadastroRoutingModule,
    ReactiveFormsModule,
    NgxMaskModule
  ],
  providers: [
    AnuncioService
  ],
  exports: [
    AnuncioCadastroComponent
  ]
})
export class AnuncioCadastroModule { }
