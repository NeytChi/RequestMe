using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace RequestMe.Controllers
{
    [ApiController]
    public class RequestMeController : ControllerBase
    {
        private readonly RequestMonitor _monitor;
        private readonly ILogger _logger;
        
        public RequestMeController()
        {
            _monitor = new RequestMonitor();
            _logger = new LoggerConfiguration()
                .WriteTo.File("./logs/log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
        [Route("/{name}/{secondName}/{lastName}/{paName}/{maName}")]
        public async Task<IActionResult> Handle(string name = null, string secondName = null, string lastName = null, string paName = null, string maName = null)
        {
            await Task.Run(() => _logger.Information
            ("Server start handle incoming request for IP -> " 
             + HttpContext.Connection.RemoteIpAddress));
            return Ok(_monitor.HandleRequest(HttpContext));
        }
        [Route("/{name}/{secondName}/{lastName}/{paName}")]
        public async Task<IActionResult> Handle(string name = null, string secondName = null, string lastName = null, string paName = null)
        {
            await Task.Run(() => _logger.Information
            ("Server start handle incoming request for IP -> " 
             + HttpContext.Connection.RemoteIpAddress));
            return Ok(_monitor.HandleRequest(HttpContext));
        }
        [Route("/{name}/{secondName}/{lastName}")]
        public async Task<IActionResult> Handle(string name = null, string secondName = null, string lastName = null)
        {
            await Task.Run(() => _logger.Information
                ("Server start handle incoming request for IP -> " 
                 + HttpContext.Connection.RemoteIpAddress));
            return Ok(_monitor.HandleRequest(HttpContext));
        }
        [Route("/{name}/{secondName}")]
        public async Task<IActionResult> Handle(string name = null, string secondName = null)
        {
            await Task.Run(() => _logger.Information
            ("Server start handle incoming request for IP -> " 
             + HttpContext.Connection.RemoteIpAddress));
            return Ok(_monitor.HandleRequest(HttpContext));
        }
        [Route("/{name}")]
        public async Task<IActionResult> Handle(string name = null)
        {
            await Task.Run(() => _logger.Information
            ("Server start handle incoming request for IP -> " 
             + HttpContext.Connection.RemoteIpAddress));
            return Ok(_monitor.HandleRequest(HttpContext));
        }
        [Route("")]
        public async Task<IActionResult> Handle()
        {
            await Task.Run(() => _logger.Information
            ("Server start handle incoming request for IP -> " 
             + HttpContext.Connection.RemoteIpAddress));
            return Ok(_monitor.HandleRequest(HttpContext));
        }
    }
}