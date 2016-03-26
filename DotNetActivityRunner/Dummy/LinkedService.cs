using Newtonsoft.Json;

namespace DotNetActivityRunner.Dummy
{
    public class LinkedService
    {
        [JsonProperty("name")]
        public string Name { get; internal set; }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Name.Equals((obj as LinkedService).Name);
        }
    }
}