using DataIngestion.TestAssignment.Entities;
using Elasticsearch.Net;
using MediatR;
using Nest;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataIngestion.TestAssignment.Files.Commands
{
    public class CreateCollectionCommandHandler : IRequestHandler<CreateCollectionCommand, BulkResponse>
    {
        private ElasticClient _client;
        private BulkResponse _blkResponse;

        public CreateCollectionCommandHandler(ElasticClient client)
        {
            _client = client;
            _blkResponse = new BulkResponse();
        }
        public async Task<BulkResponse> Handle(CreateCollectionCommand request, CancellationToken cancellationToken)
        {

            var blkOperations = request.Collection.Select(
                alb => new BulkIndexOperation<LinkFireCollection>(alb))
                    .Cast<IBulkOperation>().ToList();

            var blkRequest = new BulkRequest()
            {
                Refresh = new Refresh(),
                Operations = blkOperations
            };

            _blkResponse = await _client.BulkAsync(blkRequest);

            if (_blkResponse.Errors)
            {
                //TODO Log
            }

            return await Task.FromResult(_blkResponse);
        }
    }
}
