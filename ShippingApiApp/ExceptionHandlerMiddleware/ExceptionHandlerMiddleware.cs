namespace ShippingApiApp.ExceptionHandlerMiddleware
{
    /// <summary>
    /// ExceptionHandlerMiddleware is responsible for catching any unhandled exceptions that occur during 
    ///  the processing of an HTTP request and returning an appropriate response to the client.
    /// </summary>
    /// <returns>By default, this response has a 500 Internal Server Error status code and includes information about the exception in the response body.</returns>

    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        /// Constructor to initiate RequestDelegate
        /// </summary>
        /// <param name="next"></param>
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IConfiguration configuration)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                HttpResponse ExceptionResponse = context.Response;
                ExceptionResponse.ContentType = "application/json";
                ExceptionResponse.StatusCode = 500;
                ErrorResponseModel oError = new("We're not quite sure what went wrong. You can go back, or try looking on our Help Center if you need a hand."); ;
                string jsonresult = JsonConvert.SerializeObject(oError);
                await ExceptionResponse.WriteAsync(jsonresult);
            }
        }

    }
}
