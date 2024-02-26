using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests.Helpers
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly HttpResponseMessage _response;

        public MockHttpMessageHandler(HttpResponseMessage response)
        {
            _response = response;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var responseTask = new TaskCompletionSource<HttpResponseMessage>();
            responseTask.SetResult(_response);
            return responseTask.Task;
        }
    }
}
