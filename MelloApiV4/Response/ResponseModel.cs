using MelloApiV4.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MelloApi.Response
{
    public class ResponseModel : IResponseModel
    {
        public bool Success { get; set; }
        public IList<string> Messages { get; set; } = new List<string>();
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

        protected ResponseModel(bool success) : this()
        {
            Success = success;
        }

        protected ResponseModel()
        {

        }

        public void Failure(string message)
        {
            Success = false;
            Messages.Add(message);
        }

        public void Successful(string message)
        {
            Success = true;

            if (message != null)
            {
                Messages.Add(message);
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static T Empty<T>() where T : IResponseModel
        {
            return Activator.CreateInstance<T>();
        }

        public class Factory
        {
            public static ResponseModel CreateSuccessfulResponseModel(IEnumerable<string> messages)
            {
                var responseModel =
                    new ResponseModel(true);

                foreach (var message in messages)
                {
                    responseModel.Messages.Add(message);
                }

                return responseModel;
            }

            public static ResponseModel CreateSuccessfulResponseModel(string message, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
            {
                var responseModel =
                    new ResponseModel(true);
                responseModel.Successful(message);
                responseModel.StatusCode = httpStatusCode;
                return responseModel;
            }

            public static ResponseModel CreateFailedResponseModel(string message, HttpStatusCode statusCode = HttpStatusCode.OK)
            {
                return CreateFailedResponseModel(new[] { message }, statusCode);
            }

            public static ResponseModel CreateFailedResponseModel(IEnumerable<string> messages, HttpStatusCode statusCode = HttpStatusCode.OK)
            {
                var responseModel =
                    new ResponseModel(false) { StatusCode = statusCode };

                foreach (var message in messages)
                {
                    responseModel.Messages.Add(message);
                }
                return responseModel;
            }
        }
    }
}
