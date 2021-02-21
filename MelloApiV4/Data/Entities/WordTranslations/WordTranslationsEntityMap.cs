using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data.Entities.WordTranslations
{
    public class WordTranslationsEntityMap : DommelEntityMap<WordTranslationsEntity>
    {

        public WordTranslationsEntityMap()
        {
            ToTable("WordTranslations");

            Map(e => e.Id)
                .ToColumn("Id")
                .IsKey();
        }
    }
}
