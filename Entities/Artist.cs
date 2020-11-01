using Nest;

namespace DataIngestion.TestAssignment.Entities
{
    [ElasticsearchType]
    public class Artist
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
