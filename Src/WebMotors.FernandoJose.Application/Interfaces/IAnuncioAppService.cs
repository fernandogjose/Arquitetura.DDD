using System.Collections.Generic;
using WebMotors.FernandoJose.Application.ViewModels;

namespace WebMotors.FernandoJose.Application.Interfaces
{
    public interface IAnuncioAppService
    {
        AnuncioAdicionarResponse Adicionar(AnuncioAdicionarRequest request);

        AnuncioEditarResponse Editar(AnuncioEditarRequest request);

        AnuncioDeletarResponse Deletar(int request);

        AnuncioObterResponse Obter(AnuncioObterRequest request);

        IEnumerable<AnuncioListarResponse> Listar(AnuncioListarRequest request);
    }
}
