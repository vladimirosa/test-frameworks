using apiRestTemplate.Entities;
using System.Collections.Generic;
using System.Net.Http;
using testFrameworks.apiRest.Client;
using testFrameworks.apiRest.Entities;

namespace apiRestTemplate.Context
{
    class testContext: IContext
    {
        public ApiRestClient<User> testClient { get; }
        public List<HttpRequestMessage> RequestMessages { get; set; }
        public List<HttpResponseMessage> ResponseMessages { get; set; }
        
        public testContext()
        {
            this.testClient = new ApiRestClient<User>();
            this.ResponseMessages = new List<HttpResponseMessage>();
        }
    }
}
