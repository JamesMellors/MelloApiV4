using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Data
{
    public interface IEntity
    {
        int Id { get; set; }

        bool IsCompositeEntity();
    }
}
