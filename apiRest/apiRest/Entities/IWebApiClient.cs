using System;
using System.Net.Http;

namespace testFrameworks.apiRest.Entities
{
    public interface IWebApiClient<T> : IDisposable where T : IResource
    {
        HttpResponseMessage Post(T resource);

        HttpResponseMessage Post(string uri);

        HttpResponseMessage Post(T resource, string uri);
        
        HttpResponseMessage Put(T resource);

        HttpResponseMessage Put(T resource, string uri);

        HttpResponseMessage Get();

        HttpResponseMessage Get(T resource);

        HttpResponseMessage Get(string uri);

        HttpResponseMessage Get(T resource, string uri);

        HttpResponseMessage Delete(T resource);

        HttpResponseMessage Delete(string uri);
    }
}
