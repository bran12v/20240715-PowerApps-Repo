using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Extensions.CosmosDB;
using System.Net;
using Microsoft.Azure.Cosmos;

namespace ProductFunction
{
    public class getProductById
    {
        private readonly ILogger<getProductById> _logger; // logger, Console.writeline

        public getProductById(ILogger<getProductById> logger) // dependency injection
        {
            _logger = logger;
        }

        [Function("getProductById")] // get all products
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "getProductById")]
            HttpRequestData req, FunctionContext executionContext)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            if (executionContext == null)
            {
                var res = req.CreateResponse(HttpStatusCode.NoContent); // if no execContext, then NoContent, 204
                return res;
            }
            // Create a reference to the cosmosDB instance in our code
            using CosmosClient client = new(
                connectionString: "ENTER CONNECTION STRING HERE"
            );

            var response = req.CreateResponse(HttpStatusCode.OK); // 200
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");
            try
            {
                // query for a single product in the DB
                var item = await client.GetContainer("SampleDB", "SampleContainer").ReadItemAsync<Product>(
                    executionContext.BindingContext.BindingData["id"]!.ToString(),
                    new PartitionKey(executionContext.BindingContext.BindingData["categoryId"]!.ToString())
                );
                response.WriteString(item.Resource.ToString() ?? "");
            }
            catch (Exception ex)
            {
                response.WriteString(ex.Message);
            }
            return response;
        }
    }
}
