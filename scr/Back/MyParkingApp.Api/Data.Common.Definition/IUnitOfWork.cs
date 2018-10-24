using System.Collections.Generic;
using Core.DataTransferObject;
using Microsoft.EntityFrameworkCore;

namespace Data.Common.Definition
{
    public interface IUnitOfWork
    {

        DbSet<TEntity> CreateSet<TEntity>() where TEntity : class;

        int CommitInt();
        void RollbackChanges();
        void AttachEntity<T>(T item) where T : class;
        void AddEntity<T>(T item) where T : class;
        void RemoveEntity<T>(T item) where T : class;

        int ExecuteQuery(string query, List<ParameterDto> parameters, bool procedure);
    }
}
