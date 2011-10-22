namespace SearchParty.Infrastructure
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }

        public string StatusDescription { get; set; }

        public object[] Errors { get; set; }
    }
}