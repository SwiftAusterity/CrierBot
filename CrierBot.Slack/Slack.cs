using System;
using System.Threading.Tasks;
using Slackbot;
using System.Linq;

public class HelloRTMSession
{
    public string url { get; set; }
    public bool Ok { get; set; }
    public string Error { get; set; }
}

public class SlackUserList
{
    public SlackUser[] Members;
}

public class SlackUser
{
    public string Id;
    public string Name;
}

public class Slack
{
    IHttp http;

    public Slack(IHttp http)
    {
        this.http = http;
    }
    public async Task<string> GetUsername(string token, string userId)
    {
        var uri = $"https://slack.com/api/users.list?token={token}";

        try
        {
            var result = await http.Get(uri);

            return JSON.Deserialize<SlackUserList>(result.Body).Members.First(member => member.Id == userId).Name;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    public async Task<string> GetWebsocketUrl(string token)
    {
        var uri = $"https://slack.com/api/rtm.start?token={token}";

        try
        {
            var result = await http.Get(uri);

            return JSON.Deserialize<HelloRTMSession>(result.Body).url;
        }
        catch (Exception ex)
        {
            throw new Exception("Error getting Slack Websocket Url", ex);
        }
    }
}