

using MelloApiV4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Repository
{
    public interface IRepository<TEntity> :
        IDatabaseReader<TEntity>,
        IDatabaseWriter<TEntity> where TEntity : class, IEntity
    {

    }
}
