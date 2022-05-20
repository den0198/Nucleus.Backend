namespace Models.GraphQl;

public sealed class ErrorResponseGraphQl
{
    public IEnumerable<GraphQlError> Errors { get; set; }

    public sealed class GraphQlError
    {
        public Extensions Error { get; set; }

        public sealed class Extensions
        {
            public int Code { get; set; }
        }
    }
}

