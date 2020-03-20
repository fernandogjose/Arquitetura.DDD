import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { AnuncioAdicionarRequestModel, AnuncioAdicionarResponseModel, AnuncioListarResponseModel, AnuncioDeletarResponseModel, AnuncioObterResponseModel, AnuncioEditarRequestModel, AnuncioEditarResponseModel } from '../../models/anuncio.model';
import { MarcaListarResponseModel } from 'src/app/models/marca.model';
import { ModeloListarResponseModel } from 'src/app/models/modelo.model';
import { VersaoListarResponseModel } from 'src/app/models/versao.model';

@Injectable({
  providedIn: 'root'
})
export class AnuncioService {
  public headers: Headers = new Headers();

  constructor(private http: HttpClient) { }

  adicionar(request: AnuncioAdicionarRequestModel): Observable<AnuncioAdicionarResponseModel> {
    return this.http.post<AnuncioAdicionarResponseModel>(`${environment.apiUrl}/anuncio/adicionar`, request);
  }

  editar(request: AnuncioEditarRequestModel): Observable<AnuncioEditarResponseModel> {
    return this.http.put<AnuncioEditarResponseModel>(`${environment.apiUrl}/anuncio/editar`, request);
  }

  deletar(request: number): Observable<AnuncioDeletarResponseModel> {
    return this.http.delete<AnuncioDeletarResponseModel>(`${environment.apiUrl}/anuncio/deletar/${request}`);
  }

  obter(id: number): Observable<AnuncioObterResponseModel> {
    return this.http.get<AnuncioObterResponseModel>(`${environment.apiUrl}/anuncio/obter/${id}`);
  }

  listar(): Observable<AnuncioListarResponseModel[]> {
    return this.http.get<AnuncioListarResponseModel[]>(`${environment.apiUrl}/anuncio/listar`);
  }

  listarMarca(): Observable<MarcaListarResponseModel[]> {
    return this.http.get<MarcaListarResponseModel[]>(`http://desafioonline.webmotors.com.br/api/OnlineChallenge/Make`);
  }

  listarModelo(makeID: number): Observable<ModeloListarResponseModel[]> {
    return this.http.get<ModeloListarResponseModel[]>(`http://desafioonline.webmotors.com.br/api/OnlineChallenge/Model?MakeID=${makeID}`);
  }

  listarVersao(modelID: number): Observable<VersaoListarResponseModel[]> {
    return this.http.get<VersaoListarResponseModel[]>(`http://desafioonline.webmotors.com.br/api/OnlineChallenge/Version?ModelID=${modelID}`);
  }
}
