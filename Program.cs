using DataIngestion.TestAssignment.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace DataIngestion.TestAssignment
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                              .AddHttpClient()
                              .AddElasticSearch(indexName: "albums")
                              .AddSingleton<IHostedService, LinkFireConsole>()
                              .AddMediatR(Assembly.GetExecutingAssembly())
                              .BuildServiceProvider();


            var mediatr = serviceProvider.GetService<IMediator>();
            await new LinkFireConsole(mediatr).StartAsync(CancellationToken.None);
        }
    }
}
