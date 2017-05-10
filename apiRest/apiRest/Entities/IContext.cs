using System.Collections.Generic;
using System.Net.Http;

namespace testFrameworks.apiRest.Entities
{
    public interface IContext
    {
        List<HttpResponseMessage> ResponseMessages { get; set; }
    }
}
