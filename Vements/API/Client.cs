/*
Copyright 2023 Monster Street Systems LLC

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the “Software”), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using RestSharp;

namespace Vements.API
{
    public class Client
    {
        public readonly AchievementResource achievement;
        public readonly ParticipantResource participant;
        public readonly ScoreboardResource scoreboard;
        public readonly string baseUrl;

        public Client(string apiKey, List<string> tags)
        {
            var config = new Config();
            var url = config.serverUrl(tags);
            if (url == null)
            {
                throw new Exception("No server URL found for tags: " + string.Join(",", tags));
            }
            var endpoint = new RestClient(url);
            endpoint.AddDefaultHeader("X-API-Key", apiKey);
            achievement = new AchievementResource(endpoint);
            participant = new ParticipantResource(endpoint);
            scoreboard = new ScoreboardResource(endpoint);
            baseUrl = url;
        }

        public Client(string apiKey)
        {
            var config = new Config();
            var tags = new List<string> { "production" };
            var t = Environment.GetEnvironmentVariable("SERVER_TAGS");
            if (t != null)
            {
                tags = t.Split(",").ToList();
            }

            var url = config.serverUrl(tags);
            if (url == null)
            {
                throw new Exception("No server URL found for tags: " + string.Join(",", tags));
            }
            var endpoint = new RestClient(url);
            endpoint.AddDefaultHeader("X-API-Key", apiKey);
            achievement = new AchievementResource(endpoint);
            participant = new ParticipantResource(endpoint);
            scoreboard = new ScoreboardResource(endpoint);
            baseUrl = url;
        }

        public Client(string apiKey, string url)
        {
            var endpoint = new RestClient(url);
            endpoint.AddDefaultHeader("X-API-Key", apiKey);
            achievement = new AchievementResource(endpoint);
            participant = new ParticipantResource(endpoint);
            scoreboard = new ScoreboardResource(endpoint);
            baseUrl = url;
        }
    }
}

