using Neo4j.Driver;
using ServiceStack.Caching;
using ServiceStack.Caching.Neo4j;
using ServiceStack.Server.Tests.Shared;

namespace ServiceStack.Server.Tests
{
    // ReSharper disable once InconsistentNaming
    public class Neo4jCacheClientTests : CacheClientTestsBase
    {
        public override ICacheClient CreateClient()
        {
            var cache = new Neo4jCacheClient(GraphDatabase.Driver("bolt://localhost:7687"));
            cache.InitSchema();

            return cache;
        }

        public override void SetUp()
        {
            base.SetUp();
            
            Neo4jCacheClient.InitMappers();
        }
    }
}