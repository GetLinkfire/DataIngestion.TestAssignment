using DataIngestion.TestAssignment.Entities;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;

namespace DataIngestion.TestAssignment.Extensions
{
    public static class ElasticsearchExtension
    {
        public static IServiceCollection AddElasticSearch(this IServiceCollection service, string indexName)
        {
            var node = "http://localhost:9200";
            var defaultIndex = indexName;

            var settings = new ConnectionSettings(new Uri(node)).DefaultIndex(defaultIndex)
                .DefaultMappingFor<LinkFireCollection>(idx => idx.IndexName(indexName));

            var client = new ElasticClient(settings);
            service.AddSingleton(client);

            client.Indices.Create("albums", idx => idx.Map<LinkFireCollection>(m => m.AutoMap()));
            return service;
        }
    }
}
