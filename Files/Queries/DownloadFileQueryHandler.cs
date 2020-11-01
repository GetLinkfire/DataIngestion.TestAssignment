using DataIngestion.TestAssignment.Utilities;
using MediatR;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataIngestion.TestAssignment.Files.Queries
{
    public class DownloadFileQueryHandler : IRequestHandler<DownloadFileQuery, HttpResponseMessage>
    {
        private HttpClient _client;

        public DownloadFileQueryHandler(IHttpClientFactory client)
        {
            _client = client.CreateClient();

            _client.BaseAddress = new Uri("https://drive.google.com");
            _client.Timeout = TimeSpan.FromMinutes(10);
        }

        public async Task<HttpResponseMessage> Handle(DownloadFileQuery request, CancellationToken cancellationToken)
        {

            var response = await _client.GetAsync($"/uc?export=download&id={request.Id}");
            if (!response.IsSuccessStatusCode) throw new ApplicationException();


            //file too big confirmation
            if (response.Content.Headers.ContentType.MediaType == "text/html")
            {
                var text = Encoding.Default.GetString(await response.Content.ReadAsByteArrayAsync());
                Console.WriteLine("Downloading...");
                return await _client.GetAsync($"/uc?export=download&id={request.Id}&confirm=" +
                    $"{QueryUtils.GetQueryValue(text)}");
            }

            return response;
        }
    }
}
