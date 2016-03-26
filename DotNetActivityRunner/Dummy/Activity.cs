using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotNetActivityRunner.Dummy
{
    public class Activity
    {
        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("typeProperties")]
        public ActivityTypeProperties TypeProperties { get; internal set; }

        [JsonProperty("inputs")]
        public List<ActivityInput> Inputs { get; internal set; }

        [JsonProperty("outputs")]
        public List<ActivityOutput> Outputs { get; internal set; }

        [JsonProperty("linkedServiceName")]
        public string LinkedServiceName { get; internal set; }
    }
}