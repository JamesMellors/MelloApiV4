using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MelloApiV4.Extensions
{
    public static class StringExtensions
    {

        public static string ToJwsFormat(this string bearerToken)
        {
            return bearerToken.Replace("Bearer", string.Empty).Trim();
        }

        public static bool IsValidJwsFormat(this string token)
        {
            return !token.Contains("Bearer");
        }

        public static string ToGenderCharacter(this string gender)
        {
            var formmattedGender = gender.ToLower().Trim();

            if (formmattedGender.StartsWith("m") ||
                formmattedGender.StartsWith("f") ||
                formmattedGender.StartsWith("o"))
            {
                return ToSingleCharacter(gender).ToUpper();
            }

            return "O";
        }

        public static string ToSingleCharacter(this string value)
        {
            return value?.Substring(0, 1);
        }

     
        public static Guid ToGuid(this string value)
        {
            if (Guid.TryParse(value, out var guid))
            {
                return guid;
            }

            return Guid.Empty;
        }

        public static string ExtractFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            return fileName.Split('.').LastOrDefault()?.ToLower();
        }

      
        public static bool CanBeParsedAsEnum<T>(this int value)
        {
            return Enum.IsDefined(typeof(T), value);
        }

        public static bool CanBeParsedAsEnum<T>(this string value)
        {
            return Enum.TryParse(typeof(T), value?.ToLower(), true, out _);
        }

        public static T ParseAsEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static T ParseAsEnum<T>(this int value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        public static bool ToBoolean(this string value)
        {
            if (string.IsNullOrEmpty(value)) { return false; }

            switch (value.ToLower())
            {
                case "yes":
                case "1":
                case "true":
                    return true;
                default:
                    return false;
            }
        }
    }
}
