using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FunctionDemo
{
    public static class FunctionCalculo
    {
        [FunctionName("FunctionCalculo")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req,
            TraceWriter log)
        {
            var numeros = await req.Content.ReadAsAsync<NumerosDTO>();
            return req.CreateResponse(HttpStatusCode.OK, new { resultado = numeros.Numero1 + numeros.Numero2 });
        }
    }
}
