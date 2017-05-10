using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using testFrameworks.apiRest.Entities;

namespace testFrameworks.apiRest.Utils
{
    class MessagesUtils
    {
        public static HttpResponseMessage GetLastMessage(IContext contextField)
        {
            List<HttpResponseMessage> messages =
                            contextField.ResponseMessages;

            messages.Should().NotBeNullOrEmpty();

            HttpResponseMessage message =
                messages.Last();
            return message;
        }

        public static string[] GetLastLocationAsArray(IContext contextField)
        {
            HttpResponseMessage message = GetLastMessage(contextField);
            return message.Headers.Location.Segments.ToArray();
        }
    }
}
