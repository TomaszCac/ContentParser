using ContentParserProject.Interfaces;
using ContentParserProject.Models;
using CsvHelper;
using System.Globalization;
using System.Text.Json;

namespace ContentParserProject.Service
{
    public class ContentParser : IContentParser
    {
        public ParseResponse HandleJson(string data)
        {
            JsonElement element = JsonSerializer.Deserialize<JsonElement>(data);
            int count = CountJson(element);
            return new ParseResponse(Status.Completed, count, element);
        }

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
