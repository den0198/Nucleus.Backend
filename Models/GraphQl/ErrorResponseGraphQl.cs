using System.Text.Json.Serialization;

namespace Models.GraphQl;

public sealed class ErrorResponseGraphQl
{
    [JsonPropertyName("errors")]
    public IEnumerable<GraphQlError> Errors { get; set; }

    public sealed class GraphQlError
    {
        [JsonPropertyName("extensions")]
        public GraphQlExtensions Errors { get; set; }

        public sealed class GraphQlExtensions
        {
            [JsonPropertyName("code")]
            public string Code { get; set; }
        }
    }
}

