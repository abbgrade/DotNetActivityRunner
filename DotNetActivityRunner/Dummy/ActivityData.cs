using Newtonsoft.Json;

namespace DotNetActivityRunner.Dummy
{
    public class ActivityData
    {
        [JsonProperty("name")]
        public string Name { get; internal set; }
    }
}