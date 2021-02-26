using MelloApi.Response;
using MelloApiV4.Data.Entities.WordTranslations;
using MelloApiV4.Queries.Language.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Response.App
{
    public class AllTranslationsResponseModel : ResponseModel
    {
        public IList<TranslationsDto> translations { get; set; }
        public new static class Factory
        {

            public static AllTranslationsResponseModel SendTranslations(IList<WordTranslationsEntity> translations)
            {

                var translationDtos = translations?
                                .Select(t =>
                                {
                                    var translation = new TranslationsDto(
                                        t.English,
                                        t.German,
                                        t.Description,
                                        t.GroupId
                                        );

                                    return translation;
                                }).ToList() ?? new List<TranslationsDto>();

                AllTranslationsResponseModel response = new AllTranslationsResponseModel()
                {
                    Messages = new string[] { "Translation returned" },
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Success = true,
                    translations = translationDtos

                };
                return response;
            }

        }
    }
}
