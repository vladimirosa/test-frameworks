namespace testFrameworks.apiRest.Configuration
{
    public class HttpClientConfig
    {
        public string BaseUri { get; set; }
        public string RelativeUri { get; set; }
        public int Timeout { get; set; }
        public string AuthorizationHeader { get; set; }
        public string Encoding { get; set; }
    }
}
