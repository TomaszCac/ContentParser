using System.Globalization;
using System.Text.Json;
using ContentParserProject.Interfaces;
using ContentParserProject.Models;
using CsvHelper;

namespace ContentParserProject.Service
{
    public class ContentParser : IContentParser
    {
        //Method to parse INTERNAL_JSON
        public ParseResponse HandleJson(string data)
        {
            JsonElement element = JsonSerializer.Deserialize<JsonElement>(data);
            int count = CountJson(element);
            return new ParseResponse(Status.Completed, count, element);
        }

        //Method to parse CSV
        public ParseResponse HandleCSV(string data)
        {
            using var reader = new StringReader(data);
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();
                JsonElement element = JsonSerializer.SerializeToElement(records);
                int count = element.GetArrayLength();
                return new ParseResponse(Status.Completed, count, element);
            }
            ;
        }

        //Method counting all OBJECTS not properties or arrays
        public int CountJson(JsonElement element)
        {
            int objCount = 0;
            if (element.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in element.EnumerateArray())
                {
                    if (item.ValueKind == JsonValueKind.Object)
                    {
                        objCount += CountJson(item);
                    }
                }
            }
            else if (element.ValueKind == JsonValueKind.Object)
            {
                objCount++;
                foreach (var item in element.EnumerateObject())
                {
                    objCount += CountJson(item.Value);
                }
            }
            return objCount;
        }
    }
}
