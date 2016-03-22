using Newtonsoft.Json;

namespace DotNetActivityRunner
{
    public class ActivityData
    {
        [JsonProperty("name")]
        public string Name { get; internal set; }
    }
}