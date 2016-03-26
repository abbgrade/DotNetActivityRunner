using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotNetActivityRunner.Dummy
{
    public class PipelineProperties
    {
        [JsonProperty("activities")]
        public List<Activity> Activities { get; set; }
    }
}