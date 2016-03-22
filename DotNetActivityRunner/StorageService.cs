using Newtonsoft.Json;

namespace DotNetActivityRunner
{
    public class StorageService : LinkedService
    {
        [JsonProperty("properties")]
        public StorageServiceProperties Properties { get; internal set; }
    }
}