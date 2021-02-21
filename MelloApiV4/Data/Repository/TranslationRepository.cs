using Dapper;
using MelloApiV4.Data.Entities.Translation;
using MelloApiV4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data.Repository
{
    public class TranslationRepository : Repository<TranslationEntity>, ITranslationRepository
    {
        public TranslationRepository(IDatabaseReader<TranslationEntity> databaseReader, IDatabaseWriter<TranslationEntity> databaseWriter) : base(databaseReader, databaseWriter)
        {
        }

        public async Task<TranslationEntity> GetData()
        {
            var command = new CommandDefinition("SELECT * FROM Translations");

            return await DatabaseReader.QueryFirstOrDefault(command);
        }
    }
}
