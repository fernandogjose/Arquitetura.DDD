import { ErroModel } from './erro.model';

export class AnuncioAdicionarRequestModel {
  public marca: string;
  public modelo: string;
  public versao: string;
  public Observacao: string;
  public ano: number;
  public quilometragem: number;
}

export class AnuncioAdicionarResponseModel {
  public id: number;
  public erros: ErroModel[];
}

export class AnuncioEditarRequestModel {
  public id: number;
  public marca: string;
  public modelo: string;
  public versao: string;
  public Observacao: string;
  public ano: number;
  public quilometragem: number;
}

export class AnuncioListarResponseModel {
  public id: number;
  public marca: string;
  public modelo: string;
  public versao: string;
  public ano: number;
  public quilometragem: number;
}

export class AnuncioObterResponseModel {
  public id: number;
  public marca: string;
  public modelo: string;
  public versao: string;
  public ano: number;
  public quilometragem: number;
  public observacao: string;
}

export class AnuncioDeletarResponseModel {
  public erros: ErroModel[];
}

export class AnuncioEditarResponseModel {
  public erros: ErroModel[];
}
