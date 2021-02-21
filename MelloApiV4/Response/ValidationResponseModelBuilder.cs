
using MelloApiV4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelloApiV4.Response
{
    public class ValidationResponseModelBuilder : ResponseModelBuilder, IValidationResponseModelBuilder
    {
        private int _errorCount;
        public IValidationResponseModelBuilder AddErrorCount(IEnumerable<string> messages)
        {
            _errorCount = messages?.Count() ?? 0;
            return this;
        }

        public override IResponseModel Build()
        {
            var model =
                new ValidationResponseModel(
                    SuccessValue,
                    new List<string>(Messages),
                    _errorCount);

            _errorCount = 0;
            SuccessValue = false;
            Messages.Clear();

            return model;
        }
    }
}
