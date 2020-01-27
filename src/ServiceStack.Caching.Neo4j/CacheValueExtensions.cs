using ServiceStack.Text;

namespace ServiceStack.Caching.Neo4j
{
    internal static class CacheValueExtensions
    {
        public static string Serialize<T>(this T value)
        {
            using (JsConfig.With(new Config {ExcludeTypeInfo = false}))
            {
                return new TypeSerializer<T>().SerializeToString(value);
            }
        }

        public static T Deserialize<T>(this ICacheEntry cacheEntry)
        {
            return cacheEntry?.Data == null 
                ? default 
                : new TypeSerializer<T>().DeserializeFromString(cacheEntry.Data);
        }
    }
}