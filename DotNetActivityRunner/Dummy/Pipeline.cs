using Newtonsoft.Json;

namespace DotNetActivityRunner.Dummy
{
    public class Pipeline
    {
        [JsonProperty("properties")]
        public PipelineProperties Properties { get; internal set; }
    }
}