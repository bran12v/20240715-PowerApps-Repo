using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Extensions.CosmosDB;
using System.Net;
using Microsoft.Azure.Cosmos;

namespace ProductFunction
{
    public class getAllProducts
    {
        private readonly ILogger<getAllProducts> _logger; // logger, Console.writeline

        public getAllProducts(ILogger<getAllProducts> logger) // dependency injection
        {
            _logger = logger;
        }

        [Function("getAllProducts")] // get all products
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "getAllProducts")] 
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
                // query, get all products
                using FeedIterator<Product> feed = client.GetContainer("SampleDB", "SampleContainer").GetItemQueryIterator<Product>(
                    queryText: "SELECT * FROM items"
                );

                // Iterating over query result pages
                while (feed.HasMoreResults)
                {
                    FeedResponse<Product> res = await feed.ReadNextAsync();

                    // iterate over query results
                    int i = 0;
                    foreach (Product item in res)
                    {
                        if (i == 0)
                        {
                            response.WriteString(("[" + item.ToString()) ?? "");
                            i = 1;
                        }
                        else
                        {
                            response.WriteString((", " + item.ToString()) ?? "");
                        }
                    }
                    response.WriteString("]");
                }
            }
            catch (Exception ex)
            {
                response.WriteString(ex.Message);
            }
            return response;
        }
    }
}
