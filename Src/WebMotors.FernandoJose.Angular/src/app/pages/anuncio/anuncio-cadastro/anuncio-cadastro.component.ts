import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ErroModel } from '../../../../app/models/erro.model';
import { AnuncioService } from 'src/app/services/pages/anuncio.service';
import { MarcaListarResponseModel } from 'src/app/models/marca.model';
import { AnuncioAdicionarRequestModel, AnuncioObterResponseModel, AnuncioAdicionarResponseModel, AnuncioEditarResponseModel } from 'src/app/models/anuncio.model';
import { ModeloListarResponseModel } from 'src/app/models/modelo.model';
import { VersaoListarResponseModel } from 'src/app/models/versao.model';

@Component({
  selector: 'app-anuncio-cadastro',
  templateUrl: './anuncio-cadastro.component.html',
  styleUrls: ['./anuncio-cadastro.component.scss']
})
export class AnuncioCadastroComponent implements OnInit {

  constructor(
    private anuncioService: AnuncioService,
    private activatedRoute: ActivatedRoute,
    private ts: ToastrService,
    private router: Router
  ) { }

  public id = 0;
  public erros: ErroModel[];
  public formCadastro: FormGroup = new FormGroup({
    id: new FormControl(0),
    marca: new FormControl(0),
    modelo: new FormControl(0),
    versao: new FormControl(0),
    observacao: new FormControl(''),
    ano: new FormControl(0),
    quilometragem: new FormControl(0),
  });
  public marcas: MarcaListarResponseModel[];
  public modelos: ModeloListarResponseModel[];
  public versoes: VersaoListarResponseModel[];

  ngOnInit() {

    this.listarMarca();

    if (this.activatedRoute.snapshot.params.id !== undefined && this.activatedRoute.snapshot.params.id != null) {
      this.id = Number(this.activatedRoute.snapshot.params.id);
    }

    if (this.id > 0) {
      this.obter();
    }
  }

  private listarMarca() {
    this.anuncioService.listarMarca()
      .subscribe((response: MarcaListarResponseModel[]) => {
        this.marcas = response;
      });
  }

  private validar(): boolean {
    this.erros = new Array<ErroModel>();
    if (this.formCadastro.get('marca').value === 0) {
      this.erros.push(new ErroModel(400, 'Marca é obrigatorio'));
    }

    if (this.formCadastro.get('modelo').value === 0) {
      this.erros.push(new ErroModel(400, 'Modelo é obrigatorio'));
    }

    if (this.formCadastro.get('versao').value === 0) {
      this.erros.push(new ErroModel(400, 'Versão é obrigatorio'));
    }

    return !this.erros || this.erros.length === 0;
  }

  salvar() {
    if (!this.validar()) {
      return;
    }

    if (this.id === 0) {
      this.adicionar();
    } else {
      this.editar();
    }
  }

  obter(): void {
    this.anuncioService.obter(this.id)
      .subscribe((response: AnuncioObterResponseModel) => {
        this.formCadastro.patchValue({
          id: response.id,
          marca: response.marca,
          modelo: response.modelo,
          versao: response.versao,
          observacao: response.observacao,
          ano: response.ano,
          quilometragem: response.quilometragem
        });

        this.changeMarca();
        this.changeModelo();
      }, error => {
        this.ts.error(error);
      });
  }

  adicionar() {
    this.anuncioService.adicionar(this.formCadastro.value)
      .subscribe((response: AnuncioAdicionarResponseModel) => {
        this.ts.success('Anuncio cadastrado com sucesso.');
        this.router.navigate(['/anuncio-consulta/']);
      }, error => {
        this.erros = error.error.erros;
      });
  }

  editar() {
    this.anuncioService.editar(this.formCadastro.value)
      .subscribe((response: AnuncioEditarResponseModel) => {
        this.ts.success('Anuncio editado com sucesso!');
        this.router.navigate(['/anuncio-consulta/']);
      }, error => {
        this.erros = error.error.erros;
      });
  }

  changeMarca() {
    const marcaId = this.formCadastro.get('marca').value;
    this.formCadastro.patchValue({
      modelo: 0,
      versao: 0
    });
    this.modelos = new Array<ModeloListarResponseModel>();
    this.versoes = new Array<VersaoListarResponseModel>();

    if (marcaId > 0) {
      this.anuncioService.listarModelo(marcaId)
        .subscribe((response: MarcaListarResponseModel[]) => {
          this.modelos = response;
        });
    }
  }

  changeModelo() {
    const modeloId = this.formCadastro.get('modelo').value;
    this.formCadastro.patchValue({
      versao: 0
    });
    this.versoes = new Array<VersaoListarResponseModel>();

    if (modeloId > 0) {
      this.anuncioService.listarVersao(modeloId)
        .subscribe((response: VersaoListarResponseModel[]) => {
          this.versoes = response;
        });
    }
  }
}
