using Newtonsoft.Json;

namespace DotNetActivityRunner
{
    public class TableProperties
    {
        [JsonProperty("linkedServiceName")]
        public string LinkedServiceName { get; internal set; }

        [JsonProperty("typeProperties")]
        public TableTypeProperties TypeProperties { get; internal set; }
    }
}