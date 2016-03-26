using Newtonsoft.Json;

namespace DotNetActivityRunner.Dummy
{
    public class StorageServiceProperties
    {
        [JsonProperty("typeProperties")]
        public StorageServiceTypeProperties TypeProperties { get; internal set; }
    }
}