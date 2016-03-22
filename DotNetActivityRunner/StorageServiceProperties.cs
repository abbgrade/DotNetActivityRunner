using Newtonsoft.Json;

namespace DotNetActivityRunner
{
    public class StorageServiceProperties
    {
        [JsonProperty("typeProperties")]
        public StorageServiceTypeProperties TypeProperties { get; internal set; }
    }
}