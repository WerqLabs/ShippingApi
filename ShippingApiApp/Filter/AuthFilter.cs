
namespace ShippingApiApp.Filters
{
    public class AuthFilter: ActionFilterAttribute
    {
        string APIKey = "";
        /// <summary>
        /// Validate if the API Key is correct And If Model State is valid
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            APIKey = Environment.GetEnvironmentVariable("APIKey");
            var token = context.HttpContext.Request.Headers["Authorization"];
            if (APIKey != token)
            {
                context.Result = new UnauthorizedObjectResult("Invalid Access: Please Check your token");
                return;
            }
            ModelStateDictionary _ModelStateDictionary = context.ModelState;
            if (!_ModelStateDictionary.IsValid)
            {
                ErrorResponseModel ErrorModel = new ErrorResponseModel
                {
                    PendingDetails = _ModelStateDictionary.Keys
                      .SelectMany(key => _ModelStateDictionary[key].Errors.Select(x => new ErrorResponseModel.ValidationErrorModel(key, x.ErrorMessage)))
                      .ToList()
                };
                context.Result = new BadRequestObjectResult(ErrorModel);
            }

        }

    }
}
