using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebMotors.FernandoJose.Application.Interfaces;
using WebMotors.FernandoJose.Application.ViewModels;
using WebMotors.FernandoJose.Domain.Interfaces.Repositories;
using WebMotors.FernandoJose.Domain.Interfaces.Services;
using WebMotors.FernandoJose.Domain.Models;

namespace WebMotors.FernandoJose.Application.AppServices
{
    public class AnuncioAppService : IAnuncioAppService
    {
        private readonly IMapper _mapper;
        private readonly IAnuncioService _anuncioService;
        private readonly IUnitOfWork _unitOfWork;

        public AnuncioAppService(IMapper mapper, IAnuncioService anuncioService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _anuncioService = anuncioService;
            _unitOfWork = unitOfWork;
        }

        public AnuncioAdicionarResponse Adicionar(AnuncioAdicionarRequest request)
        {
            // Criei o UnitOfWork para mostrar um controle de transação com o dapper quando for preciso
            using (_unitOfWork)
            {
                // Inicia a transação
                _unitOfWork.BeginTransaction();

                // Faz o mapeamento para a model e chama a service
                Anuncio requestModel = _mapper.Map<Anuncio>(request);
                Anuncio responseModel = _anuncioService.Adicionar(requestModel);

                // Commit ou RollBack
                if (responseModel.Erros != null && responseModel.Erros.Any())
                {
                    _unitOfWork.RollBack();
                }
                else
                {
                    _unitOfWork.CommitTransaction();
                }

                // Mapemento do response e retorna para a api
                AnuncioAdicionarResponse response = _mapper.Map<AnuncioAdicionarResponse>(responseModel);
                return response;
            }
        }

        public AnuncioDeletarResponse Deletar(int request)
        {
            // Criei o UnitOfWork para mostrar um controle de transação com o dapper quando for preciso
            using (_unitOfWork)
            {
                // Inicia a transação
                _unitOfWork.BeginTransaction();

                // Faz o mapeamento para a model e chama a service
                Anuncio responseModel = _anuncioService.Deletar(request);

                // Commit ou RollBack
                if (responseModel.Erros != null && responseModel.Erros.Any())
                {
                    _unitOfWork.RollBack();
                }
                else
                {
                    _unitOfWork.CommitTransaction();
                }

                // Mapemento do response e retorna para a api
                AnuncioDeletarResponse response = _mapper.Map<AnuncioDeletarResponse>(responseModel);
                return response;
            }
        }

        public AnuncioEditarResponse Editar(AnuncioEditarRequest request)
        {
            // Criei o UnitOfWork para mostrar um controle de transação com o dapper quando for preciso
            using (_unitOfWork)
            {
                // Inicia a transação
                _unitOfWork.BeginTransaction();

                // Faz o mapeamento para a model e chama a service
                Anuncio requestModel = _mapper.Map<Anuncio>(request);
                Anuncio responseModel = _anuncioService.Editar(requestModel);

                // Commit ou RollBack
                if (responseModel.Erros != null && responseModel.Erros.Any())
                {
                    _unitOfWork.RollBack();
                }
                else
                {
                    _unitOfWork.CommitTransaction();
                }

                // Mapemento do response e retorna para a api
                AnuncioEditarResponse response = _mapper.Map<AnuncioEditarResponse>(responseModel);
                return response;
            }
        }

        public IEnumerable<AnuncioListarResponse> Listar(AnuncioListarRequest request)
        {
            Anuncio requestModel = _mapper.Map<Anuncio>(request);
            IEnumerable<Anuncio> responseModel = _anuncioService.Listar(requestModel);
            IEnumerable<AnuncioListarResponse> response = _mapper.Map<IEnumerable<AnuncioListarResponse>>(responseModel);
            return response;
        }

        public AnuncioObterResponse Obter(AnuncioObterRequest request)
        {
            Anuncio requestModel = _mapper.Map<Anuncio>(request);
            Anuncio responseModel = _anuncioService.Obter(requestModel);
            AnuncioObterResponse response = _mapper.Map<AnuncioObterResponse>(responseModel);
            return response;
        }
    }
}
