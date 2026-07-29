using System.ComponentModel.DataAnnotations;

namespace ContentParserProject.Models
{
    public enum ParsingContentType
    {
        CSV,
        INTERNAL_JSON,
    };
    public class ParseRequest
    {
        [EnumDataType(typeof(ParsingContentType))]
        public required ParsingContentType Type { get; set; }

        public required string Content { get; set; }
    }
}
