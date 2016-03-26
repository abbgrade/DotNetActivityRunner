using Newtonsoft.Json;

namespace DotNetActivityRunner.Dummy
{
    public class StorageService : LinkedService
    {
        [JsonProperty("properties")]
        public StorageServiceProperties Properties { get; internal set; }
    }
}