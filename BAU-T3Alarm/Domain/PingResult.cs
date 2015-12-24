using System.Collections.Generic;

namespace Domain
{
    public class PingResult
    {
        public Dictionary<string, int> ProjectsWithT3 { get; set; } 
        public PingResult()
        {
            ProjectsWithT3 = new Dictionary<string, int>();
        }
    }
}