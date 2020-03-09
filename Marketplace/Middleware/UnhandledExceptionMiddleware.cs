using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Marketplace.Middleware
{
    public class UnhandledExceptionMiddleware
    {
        private readonly RequestDelegate m_next;
        private readonly ILogger m_logger;

        public UnhandledExceptionMiddleware(RequestDelegate _next, ILoggerFactory _loggerFactory)
        {
            m_next = _next;
            m_logger = _loggerFactory.CreateLogger<UnhandledExceptionMiddleware>();
        }

        public async Task Invoke(HttpContext _context)
        {
            try
            {
                await m_next(_context);
            }
            catch (Exception ex)
            {
                m_logger.LogError("Unhandled exception: {ex}", ex);
                if (_context.Response.HasStarted)
                {
                    m_logger.LogError("Response already started");
                    throw;
                }

                _context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
        }
    }
}
