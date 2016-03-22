using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotNetActivityRunner
{
    public class PipelineProperties
    {
        [JsonProperty("activities")]
        public List<Activity> Activities { get; set; }
    }
}