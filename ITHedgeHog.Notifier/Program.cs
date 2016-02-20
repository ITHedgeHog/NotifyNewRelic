using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ITHedgeHog.Notifier
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {

                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("x-api-key", options.ApiKey);
                // Create the HttpContent for the form to be posted.
                var requestContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("deployment[app_name]", options.AppName),
                    ////new KeyValuePair<string, string>("deployment[application_id]", txtAppId.Text), 
                    new KeyValuePair<string, string>("deployment[description]", options.Description),
                    new KeyValuePair<string, string>("deployment[revision]", options.Revision),
                    new KeyValuePair<string, string>("deployment[changelog]", options.ChangeLog),
                    new KeyValuePair<string, string>("deployment[user]", options.User),
                });

                // Get the response.
                HttpResponseMessage response = client.PostAsync(
                    "https://rpm.newrelic.com/deployments.xml",
                    requestContent).Result;
            }
        }
    }
}
