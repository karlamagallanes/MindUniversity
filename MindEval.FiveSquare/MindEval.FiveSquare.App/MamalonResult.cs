using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MindEval.FiveSquare.App
{
    public class MamalonResult : IHttpActionResult
    {
        private string _message;
        private HttpStatusCode _statusCode;

        public MamalonResult(HttpStatusCode statusCode,  string message)
        {
            _message = message;
            _statusCode = statusCode;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(_statusCode)
            {
                Content = new StringContent(_message)
            };
            return Task.FromResult(response);
        }
    }
}