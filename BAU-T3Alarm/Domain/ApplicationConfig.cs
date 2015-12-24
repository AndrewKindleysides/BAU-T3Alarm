using System;
using System.Configuration;

namespace Domain
{
    public class ApplicationConfig
    {
        public string Status { get; set; }
        public double WaitTime { get; set; }
        public ApplicationConfig()
        {
            Status = ConfigurationManager.AppSettings["Status"];
            WaitTime = Convert.ToDouble((string) ConfigurationManager.AppSettings["WaitTimeInSeconds"]);
        }
    }
}