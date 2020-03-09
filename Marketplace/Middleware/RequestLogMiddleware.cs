using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Marketplace.Middleware
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate m_next;
        private readonly ILogger m_logger;

        public RequestLogMiddleware(RequestDelegate _next, ILoggerFactory _loggerFactory)
        {
            m_next = _next;
            m_logger = _loggerFactory.CreateLogger<RequestLogMiddleware>();
        }

        public async Task Invoke(HttpContext _context)
        {
            try
            {
                m_logger.LogTrace("Response {method} {route}",
                    _context.Request?.Method,
                    _context.Request?.Path
                );
                await m_next(_context);
            }
            finally
            {
                m_logger.LogTrace("Response {method} {route} - {statusCode}",
                    _context.Request?.Method,
                    _context.Request?.Path,
                    _context.Response?.StatusCode
                );
            }
        }
    }
}
