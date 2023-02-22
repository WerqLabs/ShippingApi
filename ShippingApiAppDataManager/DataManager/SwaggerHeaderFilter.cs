namespace ShippingApiAppDataManagers.DataManager
{
    public class SwaggerHeaderFilter: IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            if (context.MethodInfo.GetCustomAttribute(typeof(SwaggerHeaderAttribute)) is SwaggerHeaderAttribute attribute)
            {
                var existingParam = operation.Parameters.FirstOrDefault(p =>
                    p.In == ParameterLocation.Header && p.Name == attribute.HeaderName);
                // remove description from [FromHeader] argument attribute
                if (existingParam != null)
                {
                    operation.Parameters.Remove(existingParam);
                }

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "ApiKey",
                    In = ParameterLocation.Header,
                    Required = attribute.IsRequired,
                });

            }
        }
    }
}
