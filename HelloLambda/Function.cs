using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace HelloLambda;

public class Function
{
    
    /// <summary>
    /// A simple Lambda function that takes a name from the query string and returns a greeting message.
    /// </summary>
    /// <param name="request">The API Gateway HTTP API V2 request.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns>An API Gateway HTTP API V2 response containing the greeting message.</returns>
    public APIGatewayHttpApiV2ProxyResponse FunctionHandler(APIGatewayHttpApiV2ProxyRequest request, ILambdaContext context)
    {
        request.QueryStringParameters.TryGetValue("nome", out var nome);

        nome ??= "Guilherme Yasuda";
        var mensagem = $"Olá {nome}, da AWS Lambda";

        return new APIGatewayHttpApiV2ProxyResponse
        {
            StatusCode = 200,
            Body = mensagem
        };
    }
}
