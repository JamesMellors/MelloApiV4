

using MelloApiV4.Data.Entities.Translation;
using MelloApiV4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data.Repository
{
    public interface ITranslationRepository : IRepository<TranslationEntity>
    {
        Task<TranslationEntity> GetData();
    }
}
