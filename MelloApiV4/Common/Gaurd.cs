
using MelloApiV4.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Common
{
    public static class Gaurd
    {
        public static void AgainstInvalidEnumItem<T>(string enumItem)
        {
            if (!enumItem.CanBeParsedAsEnum<T>())
            {
                throw new InvalidEnumArgumentException(nameof(T));
            }
        }

        public static void AgainstNull(object argument, string nameOfArgument)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(nameOfArgument);
            }
        }

        public static void AgainstNullOrEmpty(string argument, string nameOfArgument)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentNullException(nameOfArgument);
            }
        }

        public static void AgainstInvalidId(long id, string nameOfArgument)
        {
            if (id == 0L)
            {
                throw new ArgumentNullException(nameOfArgument);
            }
        }

        public static void AgainstEmptyCollection<T>(IEnumerable<T> collection, string nameOfArgument)
        {
            if (collection == null || !collection.Any())
            {
                throw new ArgumentNullException(nameOfArgument);
            }
        }

        public static void Requires(bool precondition)
        {
            if (!precondition)
                throw new ArgumentException("Request precondition not met");
        }
    }
}
