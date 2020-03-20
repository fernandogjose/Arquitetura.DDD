using AutoMapper;
using WebMotors.FernandoJose.Application.ViewModels;
using WebMotors.FernandoJose.Domain.Models;

namespace WebMotors.FernandoJose.Application.AutoMapper
{
    public class ViewModelToModel : Profile
    {
        public ViewModelToModel()
        {
            CreateMap<AnuncioAdicionarRequest, Anuncio>();
            CreateMap<AnuncioEditarRequest, Anuncio>();
            CreateMap<AnuncioDeletarRequest, Anuncio>();
            CreateMap<AnuncioObterRequest, Anuncio>();
            CreateMap<AnuncioListarRequest, Anuncio>();
        }
    }
}
