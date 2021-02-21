using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Repository
{
    public interface IDatabaseReader<TEntity>
    {
        Task<TEntity> Find(Guid id);

        Task<IEnumerable<TEntity>> All();

        Task<IEnumerable<TEntity>> Query(CommandDefinition command);

        Task<IEnumerable<dynamic>> QueryDynamic(CommandDefinition command);

        Task<TEntity> QueryFirstOrDefault(CommandDefinition command);

        Task<int> Count(CommandDefinition command);
    }
}
