using Newtonsoft.Json;

namespace DotNetActivityRunner
{
    public class Table
    {
        [JsonProperty("properties")]
        public TableProperties Properties { get; internal set; }

    }
}