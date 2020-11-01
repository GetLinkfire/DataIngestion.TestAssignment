using MediatR;
using System.Net.Http;

namespace DataIngestion.TestAssignment.Files.Queries
{
    public class DownloadFileQuery : IRequest<HttpResponseMessage>
    {
        public string Id { get; set; }
    }
}
