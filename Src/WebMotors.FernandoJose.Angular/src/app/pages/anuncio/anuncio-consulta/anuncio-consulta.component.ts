import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AnuncioService } from '../../../services/pages/anuncio.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AnuncioListarResponseModel, AnuncioDeletarResponseModel } from 'src/app/models/anuncio.model';

@Component({
  selector: 'app-anuncio-consulta',
  templateUrl: './anuncio-consulta.component.html',
  styleUrls: ['./anuncio-consulta.component.scss']
})

export class AnuncioConsultaComponent implements OnInit {

  public anuncios: AnuncioListarResponseModel[];

  constructor(
    private anuncioService: AnuncioService,
    private router: Router,
    private ts: ToastrService
  ) { }

  ngOnInit() {
    this.listar();
  }

  public listar(): void {
    this.anuncioService.listar()
      .subscribe((response: AnuncioListarResponseModel[]) => {
        this.anuncios = response;
      });
  }

  public deletar(id: number) {
    this.anuncioService.deletar(id)
      .subscribe((response: AnuncioDeletarResponseModel) => {
        this.listar();
      });
  }

  public editar(id: number) {
    this.router.navigate(['/anuncio-cadastro/' + id]);
  }
}
