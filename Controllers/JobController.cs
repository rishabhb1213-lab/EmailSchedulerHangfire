using EmailSchedulerHangfire.Services;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailSchedulerHangfire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly EmailService _emailService;

        public JobController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("trigger")]
        public IActionResult Trigger()
        {
            BackgroundJob.Enqueue(() => _emailService.SendEmailAsync());
            return Ok("Email job triggered");
        }
    }
}
