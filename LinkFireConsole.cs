using DataIngestion.TestAssignment.Files.Commands;
using DataIngestion.TestAssignment.Files.Queries;
using DataIngestion.TestAssignment.Helpers;
using MediatR;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace DataIngestion.TestAssignment
{
    public class LinkFireConsole : IHostedService
    {
        private IMediator _mediatr;
        private ExtractFileHelper _file;
        private ParseFileHelper _parser;

        public LinkFireConsole(IMediator mediatr)
        {
            _mediatr = mediatr;
            _file = new ExtractFileHelper();
            _parser = new ParseFileHelper();
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
           
            var downloadQuery = new DownloadFileQuery
            {
                Id = "1AJ7icRJ5dfbWlQORocfrLhVyMOd242sm"
            };

            var response = await _mediatr.Send(downloadQuery);

            await _file.Extract(await response.Content.ReadAsByteArrayAsync());

            var createCollection = new CreateCollectionCommand()
            {
                Collection = _parser.ParseFile()
            };

            await _mediatr.Send(createCollection);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
