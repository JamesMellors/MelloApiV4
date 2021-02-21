using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data.Entities.Translation
{
    public class TranslationEntity : IEntity
    {
        public int Id { get; set; }

        public string English { get; set; }
        public string German { get; set; }
        public int GroupId { get; set; }

        public bool IsCompositeEntity() => false;
    }
}
