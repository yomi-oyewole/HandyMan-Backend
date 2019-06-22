using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace HandyManAPI.Helper.Security
{
    public class UnauthorizedResult : IHttpActionResult
    {
        public AuthenticationHeaderValue AuthHeaderValue { get; }
        public IHttpActionResult InnerResult { get; }
        public UnauthorizedResult(AuthenticationHeaderValue authHeaderValue, IHttpActionResult innerResult)
        {
            AuthHeaderValue = authHeaderValue;
            InnerResult = innerResult;
        }
        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await InnerResult.ExecuteAsync(cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                if (response.Headers.WwwAuthenticate.All(d => d.Scheme != AuthHeaderValue.Scheme))
                {
                    response.Headers.WwwAuthenticate.Add(AuthHeaderValue);
                }
            }

            return response;
        }
    }
}