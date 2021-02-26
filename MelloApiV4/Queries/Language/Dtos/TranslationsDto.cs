using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Queries.Language.Dtos
{
    public class TranslationsDto
    {
        public TranslationsDto(string english, string german, string description, int groupId)
        {
            English = english;
            German = german;
            Description = description;
            GroupId = groupId;
        }

        public string English { get; set; }
        public string German { get; set; }
        public string Description { get; set; }
        public int GroupId { get; set; }
    }
}
