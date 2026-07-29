using System.Text.Json;

namespace ContentParserProject.Models
{
    public enum Status { Completed, Failed }
    public class ParseResponse
    {
        public Status Status { get; init; }
        public int ParsedItemsCount { get; init; }
        public JsonElement Data { get; init;  }
    }
}
