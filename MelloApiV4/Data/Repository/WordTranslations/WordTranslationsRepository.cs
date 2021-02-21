using Dapper;
using MelloApiV4.Data.Entities.WordTranslations;
using MelloApiV4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data.Repository.WordTranslations
{
    public class WordTranslationsRepository : Repository<WordTranslationsEntity>, IWordTranslationsRepository
    {
        public WordTranslationsRepository(IDatabaseReader<WordTranslationsEntity> databaseReader, IDatabaseWriter<WordTranslationsEntity> databaseWriter) : base(databaseReader, databaseWriter)
        {
        }

        public async Task<IEnumerable<WordTranslationsEntity>> GetAll()
        {
            var command = new CommandDefinition("SELECT * FROM WordTranslations");

            return await DatabaseReader.Query(command);
        }

        public async Task<IEnumerable<WordTranslationsEntity>> GetGroup(int groupId)
        {

            var command = new CommandDefinition(
                      @"SELECT * FROM WordTranslations 
                    WHERE GroupId = @GroupId",
        new
        {
            GroupId = groupId
        });

            return await DatabaseReader.Query(command);
        }
    }
}
