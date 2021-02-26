using MediatR;
using MelloApiV4.Data.Repository.WordTranslations;
using MelloApiV4.Response;
using MelloApiV4.Response.App;
using MelloApiV4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MelloApiV4.Queries.Language
{
    public class GetTranlsationsBasedOnGroup
    {

        public class Query : IRequest<AllTranslationsResponseModel>
        {
            public int GroupId { get; set; }

        }

        public class Validator: BaseValidator<Query>
        {

        }

        public class Handler : IRequestHandler<Query, AllTranslationsResponseModel>
        {
            private readonly IWordTranslationsRepository _wordTranslationsRepository;
            public Handler(IWordTranslationsRepository wordTranslationsRepository)
            {
                _wordTranslationsRepository = wordTranslationsRepository;
            }
            public async Task<AllTranslationsResponseModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var translationList = (await _wordTranslationsRepository.GetGroup(request.GroupId)).ToList();

                return AllTranslationsResponseModel.Factory.SendTranslations(translationList);
            }
        }

    }
}
