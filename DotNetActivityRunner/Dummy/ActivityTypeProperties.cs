using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotNetActivityRunner.Dummy
{
    public class ActivityTypeProperties
    {
        [JsonProperty("extendedProperties")]
        public Dictionary<string, string> ExtendedProperties { get; internal set; } = new Dictionary<string, string>();
    }
}