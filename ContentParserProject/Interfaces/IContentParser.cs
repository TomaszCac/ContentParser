using ContentParserProject.Models;
using System.Text.Json;

namespace ContentParserProject.Interfaces
{
    public interface IContentParser
    {
        public ParseResponse HandleJson(string data);
        public ParseResponse HandleCSV(string data);
        public int CountJson(JsonElement element);
    }
}
