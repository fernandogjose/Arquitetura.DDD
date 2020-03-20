using System;
using System.Data;

namespace WebMotors.FernandoJose.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        void CommitTransaction();

        void RollBack();

        IDbConnection Connection { get; }

        IDbTransaction Transaction { get; }
    }
}
