using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Services
{
    public interface IComputerVisionService
    {

        ComputerVisionClient Authenticate(string endpoint, string key);
        Task<ImageAnalysis> AnalyzeImageUrl(ComputerVisionClient client, string imageUrl);

    }
}
