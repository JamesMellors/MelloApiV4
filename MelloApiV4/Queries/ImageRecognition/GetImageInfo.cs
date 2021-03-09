using MediatR;
using MelloApiV4.Data.Connections;
using MelloApiV4.Response;
using MelloApiV4.Services;
using MelloApiV4.Validation;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MelloApiV4.Queries.ImageRecognition
{
    public class GetImageInfo
    {
        public class Query : IRequest<IResponseModel>
        {

        }

        public class Validator : BaseValidator<Query>
        {

        }

        public class Handler : IRequestHandler<Query, IResponseModel>
        {
            private readonly IComputerVisionService _computerVisionService;
            private readonly IComputerVisionFactory _computerVisionFactory;
            public Handler(IComputerVisionService computerVisionService, IComputerVisionFactory computerVisionFactory)
            {
                _computerVisionService = computerVisionService;
                _computerVisionFactory = computerVisionFactory;
            }

            public async Task<IResponseModel> Handle(Query request, CancellationToken cancellationToken)
            {

                var endPoint = _computerVisionFactory.GetComputerVisionEndpoint();
                var key = _computerVisionFactory.GetComputerVisionKey();
                var testImage = "https://moderatorsampleimages.blob.core.windows.net/samples/sample16.png";
                var visionClient = _computerVisionService.Authenticate(endPoint, key);

                var imageData = await visionClient.AnalyzeImageAsync(testImage);

                throw new NotImplementedException();
            }
        }
    }
}
