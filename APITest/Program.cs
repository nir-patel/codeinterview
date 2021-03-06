using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
//using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;


class Result
{

    /*
     * Complete the 'getNumDraws' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER year as parameter.
     */

    public static int getNumDraws(int year)
    {
        int cnt = 1;
        var task = Task.Run(async () => await ProcessRequest(year));
        cnt = task.Result;
        return cnt;
    }

    private static async Task<int> ProcessRequest(int year)
    {
        string baseurl = "https://jsonmock.hackerrank.com/";
        string endpoint= $"api/football_matches?year={year}&page=1";
        //string endpoint = $"api/football_matches?year={year}&team1goals=team2goals";
        HttpClient apiClient = new HttpClient();
        apiClient.BaseAddress = new Uri(baseurl);
        //HttpRequestMessage reqMsg = new HttpRequestMessage(endpoint);
        //reqMsg.Method = HttpMethod.Get;

        string result = string.Empty;
        int cnt = 0;
        int page = 0;
        try
        {
            while(true)
            {
                page++;
                endpoint = $"api/football_matches?year={year}&page={page.ToString()}";
                using (HttpResponseMessage resMsg =
                await apiClient.GetAsync(endpoint).ConfigureAwait(false))
                {
                    if (resMsg.IsSuccessStatusCode)
                    {
                        result = await resMsg.Content.ReadAsStringAsync().ConfigureAwait(false);
                        APIResponse r = JsonSerializer.Deserialize<APIResponse>(result);
                        //APIResponse r = JsonConvert.DeserializeObject<APIResponse>(result);
                        if (r.data.Count() == 0)
                            break;
                        cnt = cnt + r.data.Where(d => d.team1goals == d.team2goals).Count();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            var error = ex.Message;
            cnt = -1;
        }
        return cnt;
    }

    //private static async Task<int> Callendpoints(int year)
    //{

    //}
}


public class APIResponse
{

    public APIResponse()
    {
        data = new List<Match>();
    }
    public string page { get; set; }
    public int per_page { get; set; }
    public int total { get; set; }
    public int total_pages { get; set; }
    public List<Match> data { get; set; }
}
public class Match
{

    public Match()
    {

    }
    public string competition { get; set; }
    public int year { get; set; }
    public string round { get; set; }
    public string team1 { get; set; }
    public string team2 { get; set; }
    public string team1goals { get; set; }
    public string team2goals { get; set; }
}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        Console.Write("Enter the year: ");

        int year = Convert.ToInt32(Console.ReadLine().Trim());

        var result = Result.getNumDraws(year);

        Console.WriteLine(result);

     
    }
}
