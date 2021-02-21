using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data.Entities.WordTranslations
{
    public class WordTranslationsEntity : IEntity
    {
        public int Id { get; set; }

        public string English { get; set; }
        public string German { get; set; }
        public string Description { get; set; }
        public int GroupId { get; set; }

        public bool IsCompositeEntity() => false;
    }
}
