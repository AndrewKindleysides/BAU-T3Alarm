using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Domain
{
    public class JiraRequest
    {
        private readonly WebClient _client;
        private readonly string _jiraApiUrl;

        public JiraRequest(WebClient client, string jiraApiUrl)
        {
            _client = client;
            _jiraApiUrl = jiraApiUrl;
        }
        
        public PingResult AllT3AwaitingTriage()
        {
            var mlcJiraCount = JirasWithStatusForProjectCode("Awaiting Triage", "LCSMLC");
            var mlawJiraCount = JirasWithStatusForProjectCode("Awaiting Triage", "LCSMLAW");
            var lfmJiraCount = JirasWithStatusForProjectCode("Awaiting Triage", "LCSLF");
            var iqlJiraCount = JirasWithStatusForProjectCode("Awaiting Triage", "LCSIQL");
            
            var result = new PingResult();
            
            if (mlcJiraCount > 0)
                result.ProjectsWithT3.Add("MLC", mlcJiraCount);    
            
            if (mlawJiraCount > 0)
                result.ProjectsWithT3.Add("MLAW", mlawJiraCount);

            if(lfmJiraCount > 0)
                result.ProjectsWithT3.Add("LFM", lfmJiraCount);

            if (iqlJiraCount > 0)
                result.ProjectsWithT3.Add("IQL", iqlJiraCount);

            var total = mlcJiraCount + mlawJiraCount + lfmJiraCount + iqlJiraCount;
            DisplayT3TotalForPoll(total);
            
            return result;
        }

        private static void DisplayT3TotalForPoll(int total)
        {
            Console.WriteLine(@"Time Polled: " + DateTime.Now);
            Console.WriteLine(@"Total Number of T3 Jiras Raised: " + total);
            Console.WriteLine();
        }

        private int JirasWithStatusForProjectCode(string status, string projectCode)
        {
            var url = string.Format("{0}/search?jql=status='{1}' AND project={2} AND 'T3 - Type' != 'Enhancement'", _jiraApiUrl, status, projectCode);
            try
            {
                var response = _client.DownloadString(url);
                var json = JObject.Parse(response);
                return (int)json["total"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }

    public class QueryResult
    {
        public int Total { get; set; }
        public List<Jira> Jiras { get; set; }
    }

    public class Jira
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public DateTime DateCreated { get; set; }
        public string Client { get; set; }
        public string Reporter { get; set; }
        public string Assignee { get; set; }
    }
}