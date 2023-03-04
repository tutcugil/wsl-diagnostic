using Figensoft.NET.Framework.Logging.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index(ILogging logging)
        {
            string result = "<b>WSL Performance Diagnostic</b> <br /><br />";
            DateTime requestBegin = DateTime.Now;
            result += requestBegin.ToString("yyyy-MM-dd HH:mm:ss.fff") + " - Request begin <br />";

            logging.Trace("Test 1");
            logging.Trace("Test 2");
            logging.Trace("Test 3");
            logging.Trace("Test 4");
            logging.Trace("Test 5");
            logging.Trace("Test 6");
            logging.Trace("Test 1");
            logging.Trace("Test 2");
            logging.Trace("Test 3");
            logging.Trace("Test 4");
            logging.Trace("Test 5");
            logging.Trace("Test 6");
            logging.Trace("Test 1");
            logging.Trace("Test 2");
            logging.Trace("Test 3");
            logging.Trace("Test 4");
            logging.Trace("Test 5");
            logging.Trace("Test 6");
            logging.Trace("Test 3");
            logging.Trace("Test 4");
            logging.Trace("Test 5");
            logging.Trace("Test 6");
            logging.Trace("Test 1");
            logging.Trace("Test 2");
            logging.Trace("Test 3");
            logging.Trace("Test 4");
            logging.Trace("Test 5");
            logging.Trace("Test 6");
            logging.Trace("Test 3");
            logging.Trace("Test 4");
            logging.Trace("Test 5");
            logging.Trace("Test 6");
            logging.Trace("Test 1");
            logging.Trace("Test 2");
            logging.Trace("Test 3");
            logging.Trace("Test 4");
            logging.Trace("Test 5");
            logging.Trace("Test 6");

            DateTime requestEnd = DateTime.Now; 
            result += requestEnd.ToString("yyyy-MM-dd HH:mm:ss.fff") + " - Request end <br /><br />";

            result += "<b>Request took " + (long)((requestEnd - requestBegin).TotalMilliseconds) + "ms";

            return Content(result, "text/html");
        }
    }
}
