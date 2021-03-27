using MediatR;
using MelloApiV4.Data.Connections;
using MelloApiV4.Response;
using MelloApiV4.Services;
using MelloApiV4.Validation;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MelloApiV4.Queries.ImageRecognition
{
    public class GetImageInfo
    {
        public class Query : IRequest<ImageAnalysis>
        {
            public string base64 { get; set; }

        }

        public class Validator : BaseValidator<Query>
        {

        }

        public class Handler : IRequestHandler<Query, ImageAnalysis>
        {
            private readonly IComputerVisionService _computerVisionService;
            private readonly IComputerVisionFactory _computerVisionFactory;
            public Handler(IComputerVisionService computerVisionService, IComputerVisionFactory computerVisionFactory)
            {
                _computerVisionService = computerVisionService;
                _computerVisionFactory = computerVisionFactory;
            }

            public async Task<ImageAnalysis> Handle(Query request, CancellationToken cancellationToken)
            {

                var endPoint = _computerVisionFactory.GetComputerVisionEndpoint();
                var key = _computerVisionFactory.GetComputerVisionKey();
                var testImage = "https://moderatorsampleimages.blob.core.windows.net/samples/sample16.png";
                var visionClient = _computerVisionService.Authenticate(endPoint, key);

                var imageStream = Base64IamgeToStream(request.base64);
                
                var imageData = await visionClient.AnalyzeImageInStreamAsync(imageStream);  // AnalyzeImageAsync(testImage);

                return imageData;
            } 

            private MemoryStream Base64IamgeToStream(string image)
            {
                var bytes = Convert.FromBase64String(image);
                return new MemoryStream(bytes);

            }
        }
    }
}
