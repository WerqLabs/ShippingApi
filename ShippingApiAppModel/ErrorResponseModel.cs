

namespace ShippingApiAppModel
{
    /// <summary>
    /// Error  Response Model
    /// </summary>
    public class ErrorResponseModel
    {
        public string Message { get; set; }
        public Exception ExceptionDetails { get; set; }
        public List<ValidationErrorModel> PendingDetails { get; set; }
        public IDictionary<string, object> OtherDetails { get; set; }
        public ErrorResponseModel()
        {
            Message = "Invalid request.";
        }
        public ErrorResponseModel(string msg)
        {
            Message = msg;
        }
        public static implicit operator ErrorResponseModel(string errormsg)
        {
            return new ErrorResponseModel(errormsg);
        }
        public class ValidationErrorModel
        {
            public string Field { get; }
            public string Message { get; }
            public ValidationErrorModel(string field, string message)
            {
                Field = !string.IsNullOrEmpty(field) ? field : null;
                Message = message;
            }
        }

    }
}
