using Dapper;
using System.Collections.Generic;
using WebMotors.FernandoJose.Domain.Interfaces.Repositories;
using WebMotors.FernandoJose.Domain.Models;

namespace WebMotors.FernandoJose.Data.Dapper.Repositories
{
    public class AnuncioRepository : BaseRepository, IAnuncioRepository
    {
        public AnuncioRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public int Adicionar(Anuncio request)
        {
            string sql = "" +
                         " INSERT INTO " +
                         " tb_AnuncioWebmotors (Marca, Modelo, Versao, Ano, Quilometragem, Observacao) " +
                         " VALUES  (@Marca, @Modelo, @Versao, @Ano, @Quilometragem, @Observacao);" +
                         " SELECT SCOPE_IDENTITY();";

            var id = _unitOfWork.Connection.ExecuteScalar<int>(sql, request);
            return id;
        }

        public void Deletar(int request)
        {
            string sql = "" +
                         "  DELETE tb_AnuncioWebmotors" +
                         "  WHERE Id = @Id";

            _unitOfWork.Connection.Execute(sql, new { @Id = request });
        }

        public void Editar(Anuncio request)
        {
            string sql = "" +
                         "  UPDATE tb_AnuncioWebmotors SET" +
                         "  Marca = @Marca" +
                         " ,Modelo = @Modelo" +
                         " ,Versao = @Versao" +
                         " ,Ano = @Ano" +
                         " ,Quilometragem = @Quilometragem" +
                         " ,Observacao = @Observacao " +
                         " WHERE Id = @Id";

            _unitOfWork.Connection.Execute(sql, request);
        }

        public IEnumerable<Anuncio> Listar(Anuncio request)
        {
            string sql = "SELECT Id, Marca, Modelo, Versao, Ano, Quilometragem FROM tb_AnuncioWebmotors";
            IEnumerable<Anuncio> response = _unitOfWork.Connection.Query<Anuncio>(sql, request);
            return response;
        }

        public Anuncio Obter(Anuncio request)
        {
            string sql = "SELECT Id, Marca, Modelo, Versao, Ano, Quilometragem, Observacao FROM tb_AnuncioWebmotors WHERE Id = @Id";
            Anuncio response = _unitOfWork.Connection.QueryFirst<Anuncio>(sql, request);
            return response;
        }
    }
}
