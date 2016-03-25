using Newtonsoft.Json;

namespace DotNetActivityRunner
{
    public class TableTypeProperties
    {
        [JsonProperty("folderPath")]
        public string FolderPath { get; internal set; }

        [JsonProperty("fileName")]
        public string FileName { get; internal set; }
        
        [JsonProperty("tableName")]
        public string TableName { get; internal set; }
    }
}