using MelloApiV4.Data.Entities.WordTranslations;
using MelloApiV4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data.Repository.WordTranslations
{
    public interface IWordTranslationsRepository : IRepository<WordTranslationsEntity>
    {

        Task<IEnumerable<WordTranslationsEntity>> GetAll();
        Task<IEnumerable<WordTranslationsEntity>> GetGroup(int groupId);
    }
}
