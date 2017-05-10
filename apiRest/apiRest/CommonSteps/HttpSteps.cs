using testFrameworks.apiRest.Entities;
using BoDi;
using TechTalk.SpecFlow;
using FluentAssertions;
using testFrameworks.apiRest.Utils;
using System.Net.Http;
using System.Net;

namespace testFrameworks.apiRest.CommonSteps
{
    [Binding]
    public sealed class HttpSteps
    {
        private readonly IContext contextField;
        private readonly IObjectContainer container;
        
        public HttpSteps(IContext context, IObjectContainer container)
        {
            this.contextField = context;
            this.container = container;
        }
        
        [Then("The CREATED status should be returned")]
        public void ThenTheCreatedStatusShouldBeReturned()
        {
            HttpResponseMessage message = MessagesUtils.GetLastMessage(this.contextField);

            message.Should().NotBeNull();
            message.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
        }

        [Then("The UDPATED status should be returned")]
        public void ThenTheUpdateStatusSouldBeReturned()
        {
            HttpResponseMessage message = MessagesUtils.GetLastMessage(this.contextField);

            message.Should().NotBeNull();
            message.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);
        }

        [Then("The OK status should be returned")]
        public void ThenTheOkStatusShouldBeReturned()
        {
            HttpResponseMessage message = MessagesUtils.GetLastMessage(this.contextField);

            message.Should().NotBeNull();
            message.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        [Then("The BAD REQUEST status should be returned")]
        public void ThenTheBadRequestStatusShouldBeReturned()
        {
            HttpResponseMessage message = MessagesUtils.GetLastMessage(this.contextField);

            message.Should().NotBeNull();
            message.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.BadRequest);
        }

        [Then("The CONFLICT status should be returned")]
        public void ThenTheConflictStatusShouldBeReturned()
        {
            HttpResponseMessage message = MessagesUtils.GetLastMessage(this.contextField);

            message.Should().NotBeNull();
            message.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Conflict);
        }

        [Then("An ERROR status should be returned")]
        public void ThenAErrorStatusShouldBeReturned()
        {
            HttpResponseMessage message = MessagesUtils.GetLastMessage(this.contextField);

            message.Should().NotBeNull();
            message.IsSuccessStatusCode.Should().BeFalse();
        }

        [Then("The location header should be set")]
        public void ThenTheLocationHeaderShouldBeSet()
        {
            HttpResponseMessage message = MessagesUtils.GetLastMessage(this.contextField);

            message.Should().NotBeNull();
            message.Headers.Location.Should().NotBeNull();
            message.Headers.Location.AbsoluteUri.Should().NotBeNullOrEmpty("Location is missing from header");
        }
    }
}
