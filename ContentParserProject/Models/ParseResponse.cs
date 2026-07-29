using System.Text.Json;

namespace ContentParserProject.Models
{
    public enum Status
    {
        Completed,
        Failed,
    }

    public class ParseResponse
    {
        public ParseResponse(Status status, int parsedItemsCount, JsonElement data)
        {
            Status = status;
            ParsedItemsCount = parsedItemsCount;
            Data = data;
        }

        //Status completion of parsing operation
        public Status Status { get; init; }

        //Count of parsed rows in CSV or objects in INTERNAL_JSON
        public int ParsedItemsCount { get; init; }

        //Parsed data
        public JsonElement Data { get; init; }
    }
}
