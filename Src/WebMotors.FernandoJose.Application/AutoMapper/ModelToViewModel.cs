using AutoMapper;
using WebMotors.FernandoJose.Application.ViewModels;
using WebMotors.FernandoJose.Domain.Models;

namespace WebMotors.FernandoJose.Application.AutoMapper
{
    public class ModelToViewModel : Profile
    {
        public ModelToViewModel()
        {
            CreateMap<Anuncio, AnuncioAdicionarResponse>();
            CreateMap<Anuncio, AnuncioEditarResponse>();
            CreateMap<Anuncio, AnuncioDeletarResponse>();
            CreateMap<Anuncio, AnuncioObterResponse>();
            CreateMap<Anuncio, AnuncioListarResponse>();
            CreateMap<Erro, ErroViewModel>();
        }
    }
}
