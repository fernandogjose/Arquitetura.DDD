using System.Collections.Generic;
using WebMotors.FernandoJose.Domain.Models;

namespace WebMotors.FernandoJose.Domain.Interfaces.Services
{
    public interface IAnuncioService
    {
        Anuncio Adicionar(Anuncio request);

        Anuncio Editar(Anuncio request);

        Anuncio Deletar(int id);

        Anuncio Obter(Anuncio request);

        IEnumerable<Anuncio> Listar(Anuncio request);
    }
}
