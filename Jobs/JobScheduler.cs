using EmailSchedulerHangfire.Services;
using Hangfire;

namespace EmailSchedulerHangfire.Jobs
{
    public class JobScheduler
    {
        public static void ScheduleJobs()
        {
            //RecurringJob.AddOrUpdate<EmailService>(
            //    "daily-email-job",
            //    service => service.SendEmailAsync(),
            //    //Cron.Daily(9) // 9 AM daily
            //    Cron.Minutely
            //);
            RecurringJob.AddOrUpdate<EmailService>(
            "daily-email-job",
            service => service.SendEmailAsync(),
            //"0 9,14,20 * * *"
            "*/2 * * * *"
            );
        }
    }
}
