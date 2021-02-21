
using MelloApi.Response;
using MelloApiV4.Data.Entities.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Response.App
{
    public class TranslationResponseModel : ResponseModel
    {
        public string English { get; set; }
        public string German { get; set; }
        public int GroupId { get; set; }

        public new static class Factory
        {

            public static TranslationResponseModel SendTranslation(TranslationEntity translation)
            {
                TranslationResponseModel response = new TranslationResponseModel()
                {
                    English = translation.English,
                    German = translation.German,
                    GroupId = translation.GroupId,
                    Messages = new string[] { "Translation returned" },
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Success = true

                };
                return response;
            }

        }
    }
}
