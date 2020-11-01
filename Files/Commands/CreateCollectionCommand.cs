using DataIngestion.TestAssignment.Entities;
using Nest;
using System.Collections.Generic;

namespace DataIngestion.TestAssignment.Files.Commands
{
    public class CreateCollectionCommand : MediatR.IRequest<BulkResponse>
    {
        public IEnumerable<LinkFireCollection> Collection { get; set; }
    }
}
