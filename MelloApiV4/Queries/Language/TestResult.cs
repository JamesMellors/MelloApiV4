using MediatR;
using MelloApiV4.Data.Repository;
using MelloApiV4.Response.App;
using MelloApiV4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MelloApiV4.Queries
{
    public class TestResult
    {
        public class Query : IRequest<TranslationResponseModel>
        {

        }

        public class Validator : BaseValidator<Query>
        {

        }

        public class Handler : IRequestHandler<Query, TranslationResponseModel>
        {
            private readonly ITranslationRepository _translationRepo ;
            public Handler(ITranslationRepository translationRepo)
            {
                _translationRepo = translationRepo;
            }
            public async Task<TranslationResponseModel> Handle(Query request, CancellationToken cancellationToken)
            {

               var translation = await _translationRepo.GetData();

                return TranslationResponseModel.Factory.SendTranslation(translation);
            }
        }

    }
}
