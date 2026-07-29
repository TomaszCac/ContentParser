using System.Text.Json;
using ContentParserProject.Models;

namespace ContentParserProject.Interfaces
{
    public interface IContentParser
    {
        public ParseResponse HandleJson(string data);
        public ParseResponse HandleCSV(string data);
        public int CountJson(JsonElement element);
    }
}
