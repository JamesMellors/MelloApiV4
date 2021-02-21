using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.FluentMap.Dommel.Mapping;
using Dapper.FluentMap.Mapping;

namespace MelloApiV4.Data.Entities.Translation
{
    public class TranslationEntityMap : DommelEntityMap<TranslationEntity>
    {

        public TranslationEntityMap()
        {
            ToTable("Translation");

            Map(e => e.Id)
                .ToColumn("Id")
                .IsKey();
        }
    }
}
