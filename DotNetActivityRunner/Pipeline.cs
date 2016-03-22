using Newtonsoft.Json;

namespace DotNetActivityRunner
{
    public class Pipeline
    {
        [JsonProperty("properties")]
        public PipelineProperties Properties { get; internal set; }
    }
}