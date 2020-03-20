using System.Collections.Generic;
using WebMotors.FernandoJose.Domain.Models;

namespace WebMotors.FernandoJose.Domain.Interfaces.Repositories
{
    public interface IAnuncioRepository
    {
        int Adicionar(Anuncio request);

        void Editar(Anuncio request);

        void Deletar(int request);

        Anuncio Obter(Anuncio request);

        IEnumerable<Anuncio> Listar(Anuncio request);
    }
}
