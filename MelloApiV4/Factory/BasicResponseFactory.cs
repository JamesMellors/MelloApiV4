using MelloApi.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Factory
{
    public class BasicResponseFactory : ResponseModel
    {
        public new class Factory

        {
            public static BasicResponseFactory CreateSuccessResponseModel(string message)
            {
                return new BasicResponseFactory
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Success = true,
                    Messages = new List<string> { "" }
                };
            }

            public static BasicResponseFactory CreateBadRequestModel(string message)
            {
                return new BasicResponseFactory
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Success = false,
                    Messages = new List<string> { "", message }
                };
            }

        }
        
    }
}
