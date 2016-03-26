using Newtonsoft.Json;

namespace DotNetActivityRunner.Dummy
{
    public class StorageServiceTypeProperties
    {
        [JsonProperty("connectionString")]
        public string ConnectionString { get; internal set; }
    }
}