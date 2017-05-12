using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using testFrameworks.apiRest.Configuration;
using testFrameworks.apiRest.Entities;
using System.Configuration;

namespace testFrameworks.apiRest.Client
{
    class ApiRestClient<T> : IWebApiClient<T> where T : IResource
    {
        private HttpClient httpClientField;
        private HttpClientConfig configurationField;
        
        public ApiRestClient(HttpClientConfig configuration)
        {
            this.Configuration = configuration;
        }

        public ApiRestClient()
        {
            var appSettings = ConfigurationManager.AppSettings;
            
            this.Configuration = new HttpClientConfig()
            {
                BaseUri = appSettings["baseUri"] + "/",
                RelativeUri = appSettings["endpoint"],
                Encoding = appSettings["encoding"],
                Timeout = 1000
            };
        }
        
        protected HttpClient HttpClient
        {
            get
            {
                if (this.httpClientField == null)
                {
                    this.httpClientField =
                       new HttpClient()
                       {
                           BaseAddress =
                               new Uri(new Uri(this.Configuration.BaseUri), this.Configuration.RelativeUri),
                           Timeout = new TimeSpan(0, 0, this.Configuration.Timeout)
                       };
                    this.httpClientField.DefaultRequestHeaders.Accept.Clear();
                    this.httpClientField.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(this.Configuration.Encoding));
                }

                return this.httpClientField;
            }
        }
        
        public HttpClientConfig Configuration
        {
            get
            {
                if (this.configurationField == null)
                {
                    this.configurationField =
                        new HttpClientConfig();
                }

                return
                    this.configurationField;
            }

            set
            {
                this.configurationField = value;
            }
        }
        
        public HttpResponseMessage Post(T resource)
        {
            string json = JsonConvert.SerializeObject(resource);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue(this.Configuration.Encoding);

            var response =
                this.HttpClient.PostAsync(string.Empty, content).Result;

            return response;
        }

        public HttpResponseMessage Post(string uri)
        {
            HttpContent content = new StringContent("");
            content.Headers.ContentType = new MediaTypeHeaderValue(this.Configuration.Encoding);

            var response =
                this.HttpClient.PostAsync(uri, content).Result;

            return response;
        }

        public HttpResponseMessage Post(T resource, string uri)
        {
            string json = JsonConvert.SerializeObject(resource);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue(this.Configuration.Encoding);

            var response =
                this.HttpClient.PostAsync(uri, content).Result;

            return response;
        }

        public HttpResponseMessage Put(T resource, string uri)
        {
            string json = JsonConvert.SerializeObject(resource);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue(this.Configuration.Encoding);

            var response =
                this.HttpClient.PutAsync(uri, content).Result;

            return response;
        }

        public HttpResponseMessage Put(T resource)
        {
            string json = JsonConvert.SerializeObject(resource);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue(this.Configuration.Encoding);

            var response =
                this.HttpClient.PutAsync(string.Empty, content).Result;

            return response;
        }

        public HttpResponseMessage Get()
        {
            HttpContent content = new StringContent("");
            content.Headers.ContentType = new MediaTypeHeaderValue(this.Configuration.Encoding);

            var response =
                this.HttpClient.GetAsync(string.Empty).Result;

            return response;
        }

        public HttpResponseMessage Get(T resource)
        {
            HttpContent content = new StringContent("");
            content.Headers.ContentType = new MediaTypeHeaderValue(this.Configuration.Encoding);

            var response =
                this.HttpClient.GetAsync(resource.Id).Result;

            return response;
        }

        public HttpResponseMessage Get(string uri)
        {
            HttpContent content = new StringContent("");
            content.Headers.ContentType = new MediaTypeHeaderValue(this.Configuration.Encoding);

            var response =
                this.HttpClient.GetAsync(uri).Result;

            return response;
        }

        public HttpResponseMessage Get(T resource, string uri)
        {
            HttpContent content = new StringContent("");
            content.Headers.ContentType = new MediaTypeHeaderValue(this.Configuration.Encoding);

            var response =
                this.HttpClient.GetAsync(resource.Id + uri).Result;

            return response;
        }

        public HttpResponseMessage Delete(T resource, string uri)
        {
            HttpContent content = new StringContent("");
            content.Headers.ContentType = new MediaTypeHeaderValue(this.Configuration.Encoding);

            var response =
                this.HttpClient.DeleteAsync(resource.Id + uri).Result;

            return response;
        }

        public HttpResponseMessage Delete(string uri)
        {
            HttpContent content = new StringContent("");
            content.Headers.ContentType = new MediaTypeHeaderValue(this.Configuration.Encoding);

            var response =
                this.HttpClient.DeleteAsync(uri).Result;

            return response;
        }

        public HttpResponseMessage Delete(T resource)
        {
            HttpContent content = new StringContent("");
            content.Headers.ContentType = new MediaTypeHeaderValue(this.Configuration.Encoding);

            var response =
                this.HttpClient.DeleteAsync(resource.Id).Result;

            return response;
        }

        public HttpResponseMessage DeleteWithContent(T resource)
        {
            string json = JsonConvert.SerializeObject(resource);

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(json, Encoding.UTF8, this.Configuration.Encoding),
                Method = HttpMethod.Delete,
                RequestUri = new Uri(this.Configuration.BaseUri + this.Configuration.RelativeUri)
            };
            var response = this.HttpClient.SendAsync(request).Result;

            return response;
        }

        public HttpResponseMessage DeleteWithContent(T resource, string uri)
        {
            string json = JsonConvert.SerializeObject(resource);

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(json, Encoding.UTF8, this.Configuration.Encoding),
                Method = HttpMethod.Delete,
                RequestUri = new Uri(this.Configuration.BaseUri + this.Configuration.RelativeUri + uri)
            };
            var response = this.HttpClient.SendAsync(request).Result;

            return response;
        }

        public void Dispose()
        {
            if (this.httpClientField != null)
            {
                this.httpClientField.Dispose();
            }
        }
    }
}
