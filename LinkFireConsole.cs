using MediatR;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace DataIngestion.TestAssignment
{
    public class LinkFireConsole : IHostedService
    {
        private IMediator _mediatr;

        public LinkFireConsole(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
