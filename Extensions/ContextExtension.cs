using Microsoft.AspNetCore.Http;

namespace Extension
{
    public static class ContextExtension
    {
        public static void toUtf8(this HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf8";
        }
    }
}