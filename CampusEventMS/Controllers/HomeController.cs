using CampusEventMS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CampusEventMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok(new { Message = "Welcome to the Campus Event Management System API!" });
        }

        [HttpGet("Privacy")]
        public IActionResult Privacy()
        {
            return Ok(new { Message = "Privacy Policy" });
        }

        [HttpGet("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return Ok(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
