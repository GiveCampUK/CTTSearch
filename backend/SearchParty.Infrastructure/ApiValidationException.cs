namespace SearchParty.Infrastructure
{
    using System;
    using System.Net;

    /// <summary>
    /// NOTE: BA; WIP!
    /// </summary>
    public class ApiValidationException : Exception
    {
        public ApiValidationException(object[] validationErrors)
            : base(String.Empty)
        {
            ValidationErrors = validationErrors;
            HttpStatusCode = HttpStatusCode.BadRequest;
        }

        public object[] ValidationErrors { get; set; }
        public HttpStatusCode HttpStatusCode { get; private set; }

        public static implicit operator ErrorResponse(ApiValidationException exception)
        {
            var errorResponse = new ErrorResponse
                                    {
                                        StatusCode = (int) exception.HttpStatusCode,
                                        StatusDescription = "Validation errors occured."
                                    };

            foreach (var error in exception.ValidationErrors)
            {
                //errorResponse.Errors.Add(new ErrorResponse(error.Key, error.Value));
            }

            return errorResponse;
        }
    }
}