using Newtonsoft.Json;

namespace DotNetActivityRunner
{
    public class StorageServiceTypeProperties
    {
        [JsonProperty("connectionString")]
        public string ConnectionString { get; internal set; }
    }
}