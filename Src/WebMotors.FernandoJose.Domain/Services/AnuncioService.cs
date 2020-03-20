using System.Collections.Generic;
using System.Linq;
using WebMotors.FernandoJose.Domain.Interfaces.Repositories;
using WebMotors.FernandoJose.Domain.Interfaces.Services;
using WebMotors.FernandoJose.Domain.Models;
using WebMotors.FernandoJose.Domain.Validacoes;

namespace WebMotors.FernandoJose.Domain.Services
{
    public class AnuncioService : IAnuncioService
    {
        private readonly AnuncioValidacao _anuncioValidacao;
        private readonly IAnuncioRepository _anuncioRepository;

        public AnuncioService(AnuncioValidacao anuncioValidacao, IAnuncioRepository anuncioRepository)
        {
            _anuncioValidacao = anuncioValidacao;
            _anuncioRepository = anuncioRepository;
        }

        public Anuncio Adicionar(Anuncio request)
        {
            // Crio o objeto de response
            Anuncio response = new Anuncio();

            // Validação de regras de negócio
            _anuncioValidacao.ValidarAdicionar(request);
            if (_anuncioValidacao.Erros.Any())
            {
                response.Erros = _anuncioValidacao.Erros;
                return response;
            }

            // Chama o Repositoy
            response.Id = _anuncioRepository.Adicionar(request);

            // Retorna
            return response;
        }

        public Anuncio Deletar(int request)
        {
            // Crio o objeto de response
            Anuncio response = new Anuncio();

            // Validação de regras de negócio
            _anuncioValidacao.ValidarDeletar(request);
            if (_anuncioValidacao.Erros.Any())
            {
                response.Erros = _anuncioValidacao.Erros;
                return response;
            }

            // Chama o Repositoy
            _anuncioRepository.Deletar(request);

            // Retorna
            return response;
        }

        public Anuncio Editar(Anuncio request)
        {
            // Crio o objeto de response
            Anuncio response = new Anuncio();

            // Validação de regras de negócio
            _anuncioValidacao.ValidarEditar(request);
            if (_anuncioValidacao.Erros.Any())
            {
                response.Erros = _anuncioValidacao.Erros;
                return response;
            }

            // Chama o Repositoy
            _anuncioRepository.Editar(request);

            // Retorna
            return response;
        }

        public IEnumerable<Anuncio> Listar(Anuncio request)
        {
            IEnumerable<Anuncio> response = _anuncioRepository.Listar(request);
            return response;
        }

        public Anuncio Obter(Anuncio request)
        {
            Anuncio response = _anuncioRepository.Obter(request);
            return response;
        }
    }
}
