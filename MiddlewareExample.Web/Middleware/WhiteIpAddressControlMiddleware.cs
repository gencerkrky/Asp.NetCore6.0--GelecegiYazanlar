using System.Net;

namespace MiddlewareExample.Web.Middleware
{
    public class WhiteIpAddressControlMiddleware
    {
        private readonly RequestDelegate reqestDelegate;
        private const string WhiteIpAddress = "::1";

        public WhiteIpAddressControlMiddleware(RequestDelegate reqestDelegate)
        {
            this.reqestDelegate = reqestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //Ipv4 => 127.0.0.1 localhost
            //Ipv6 =>  : : 1 localhost

            var reqIpAddress = context.Connection.RemoteIpAddress;

            bool AnyWhiteIpAddress = IPAddress.Parse(WhiteIpAddress).Equals(reqIpAddress);
            if (AnyWhiteIpAddress==true)
            {

                await reqestDelegate(context);

            }
            else
            {

                context.Response.StatusCode = HttpStatusCode.Forbidden.GetHashCode();
                await context.Response.WriteAsync("Forbiden");

            }




        }



    }
}
