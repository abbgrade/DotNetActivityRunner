using Newtonsoft.Json;

namespace DotNetActivityRunner.Dummy
{
    public class Table
    {
        [JsonProperty("properties")]
        public TableProperties Properties { get; internal set; }

    }
}