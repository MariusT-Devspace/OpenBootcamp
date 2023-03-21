using Microsoft.Extensions.Primitives;

namespace UniversityApiBackend.Extensions
{
    public static class CorrelationIdExtension
    {
        public static string GetCorrelationId(this HttpContext httpContext)
        {
            httpContext.Request.Headers.TryGetValue("Cko-Correlation-Id", out StringValues correlationId);
            return correlationId.FirstOrDefault() ?? httpContext.TraceIdentifier;
        }
    }
}
