using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AlunoLambda;

public class Function
{
    public async Task<List<Aluno>> GetAlunosAsync(APIGatewayHttpApiV2ProxyRequest request, ILambdaContext context)
    {
        AmazonDynamoDBClient client = new();

        DynamoDBContext dbContext = new DynamoDBContextBuilder()
                    .WithDynamoDBClient(() => client)
                    .ConfigureContext(config =>
                    {
                        config.DisableFetchingTableMetadata = false;
                    })
                    .Build();

        var alunos = await dbContext.ScanAsync<Aluno>([]).GetRemainingAsync();
        return alunos;
    }

    public async Task<APIGatewayHttpApiV2ProxyResponse> CreateAlunoAsync(APIGatewayHttpApiV2ProxyRequest request, ILambdaContext context)
    {
        var aluno = JsonConvert.DeserializeObject<Aluno>(request.Body);
        AmazonDynamoDBClient client = new();

        DynamoDBContext dbContext = new DynamoDBContextBuilder()
                    .WithDynamoDBClient(() => client)
                    .ConfigureContext(config =>
                    {
                        config.DisableFetchingTableMetadata = false;
                    })
                    .Build();

        await dbContext.SaveAsync(aluno);

        var mensagem = $"Aluno com Id {aluno?.Id} criado com sucesso";

        LambdaLogger.Log(mensagem);

        return new APIGatewayHttpApiV2ProxyResponse
        {
            StatusCode = 200,
            Body = mensagem
        };
    }

    public async Task<Aluno> GetAlunoPorIdAsync(APIGatewayHttpApiV2ProxyRequest request, ILambdaContext context)
    {
        var id = request.PathParameters["id"];
        AmazonDynamoDBClient client = new();

        DynamoDBContext dbContext = new DynamoDBContextBuilder()
                    .WithDynamoDBClient(() => client)
                    .ConfigureContext(config =>
                    {
                        config.DisableFetchingTableMetadata = false;
                    })
                    .Build();

        var aluno = await dbContext.LoadAsync<Aluno>(Int32.Parse(id));

        if (aluno == null) throw new Exception("Not Found!");

        return aluno;
    }
}
