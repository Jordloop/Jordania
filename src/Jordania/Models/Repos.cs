using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jordania.Models
{
    public class Repos
    {
        public string name { get; set; }
        public string html_url { get; set; }
        public string stargazers_count { get; set; }


        public static List<Repos> MyStarredRepos()
        {
            //Who we are requesting from       
            var client = new RestClient("https://api.github.com");
            //What we are requesting
            var request = new RestRequest("/search/repositories?q=user:jordloop&sort=stars", Method.GET);
            //API "Username" and "Password"
            client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.AuthName, EnvironmentVariables.AuthToken);
            //API call Header
            request.AddHeader(EnvironmentVariables.AuthName, EnvironmentVariables.AuthToken);
            request.AddHeader("User-Agent", "JordLoop");
            //Response from API call
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var repoInfo = JsonConvert.DeserializeObject<List<Repos>>(jsonResponse["items"].ToString());
            return repoInfo;
        }


        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}