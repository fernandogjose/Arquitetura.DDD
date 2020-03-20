using System.Collections.Generic;
using WebMotors.FernandoJose.Domain.Models;

namespace WebMotors.FernandoJose.Domain.Validacoes
{
    public class AnuncioValidacao
    {
        public List<Erro> Erros { get; private set; }

        private void LimpaErros()
        {
            Erros = new List<Erro>(0);
        }

        private void ValidarId(int valor)
        {
            if (valor <= 0)
            {
                Erros.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "Id é obrigatório"
                });
            }
        }

        private void ValidarMarca(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                Erros.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "Marca é obrigatório"
                });
            }
        }

        private void ValidarModelo(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                Erros.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "Modelo é obrigatório"
                });
            }
        }

        private void ValidarVersao(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                Erros.Add(new Erro
                {
                    Codigo = 400,
                    Descricao = "Versão é obrigatório"
                });
            }
        }

        public void ValidarAdicionar(Anuncio request)
        {
            LimpaErros();
            ValidarMarca(request.Marca);
            ValidarModelo(request.Modelo);
            ValidarVersao(request.Versao);
        }

        public void ValidarEditar(Anuncio request)
        {
            LimpaErros();
            ValidarId(request.Id);
            ValidarMarca(request.Marca);
            ValidarModelo(request.Modelo);
            ValidarVersao(request.Versao);
        }

        public void ValidarDeletar(int request)
        {
            LimpaErros();
            ValidarId(request);
        }
    }
}
