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

// NB: This is a generated file; any changes will be lost.

using System.Text.Json;
using System.Text.Json.Serialization;

using RestSharp;

namespace Vements.API
{
    public struct AchievementResource
    {
        private readonly RestClient endpoint;

        public AchievementResource(RestClient endpoint)
        {
            this.endpoint = endpoint;
        }

        public AchievementLeaderboardResponse? Leaderboard(string achievementId)
        {
            var path = "achievement/{achievement_id}/leaderboard";
            path = path.Replace("{achievement_id}", achievementId);
            var request = new RestRequest(path);

            try
            {
                var response = endpoint.Get(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<AchievementLeaderboardResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public AchievementProgressResponse? Record(
            string achievementId,
            AchievementProgressRequest payload
        )
        {
            var path = "achievement/{achievement_id}/progress";
            path = path.Replace("{achievement_id}", achievementId);
            var request = new RestRequest(path);

            request.AddJsonBody(JsonSerializer.Serialize(payload), contentType: "application/json");

            try
            {
                var response = endpoint.Put(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<AchievementProgressResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public AchievementListResponse? List(
            string projectId,
            int? limit = null,
            int? offset = null
        )
        {
            var path = "achievement";
            var request = new RestRequest(path);

            request.AddQueryParameter("project_id", projectId);
            limit = limit == 0 ? 100 : limit;
            if (limit != null)
            {
                request.AddQueryParameter("limit", limit.Value);
            }
            if (offset != null)
            {
                request.AddQueryParameter("offset", offset.Value);
            }

            try
            {
                var response = endpoint.Get(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<AchievementListResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public AchievementCreateResponse? Create(AchievementCreateRequest payload)
        {
            var path = "achievement";
            var request = new RestRequest(path);

            request.AddJsonBody(JsonSerializer.Serialize(payload), contentType: "application/json");

            try
            {
                var response = endpoint.Put(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<AchievementCreateResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public AchievementReadResponse? Read(string achievementId)
        {
            var path = "achievement/{achievement_id}";
            path = path.Replace("{achievement_id}", achievementId);
            var request = new RestRequest(path);

            try
            {
                var response = endpoint.Get(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<AchievementReadResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public AchievementUpdateResponse? Update(
            string achievementId,
            AchievementUpdateRequest payload
        )
        {
            var path = "achievement/{achievement_id}";
            path = path.Replace("{achievement_id}", achievementId);
            var request = new RestRequest(path);

            request.AddJsonBody(JsonSerializer.Serialize(payload), contentType: "application/json");

            try
            {
                var response = endpoint.Post(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<AchievementUpdateResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public AchievementDeleteResponse? Delete(string achievementId)
        {
            var path = "achievement/{achievement_id}";
            path = path.Replace("{achievement_id}", achievementId);
            var request = new RestRequest(path);

            try
            {
                var response = endpoint.Delete(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<AchievementDeleteResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }
    }

    public struct ParticipantResource
    {
        private readonly RestClient endpoint;

        public ParticipantResource(RestClient endpoint)
        {
            this.endpoint = endpoint;
        }

        public ParticipantProgressResponse? Progress(string participantId)
        {
            var path = "participant/{participant_id}/progress";
            path = path.Replace("{participant_id}", participantId);
            var request = new RestRequest(path);

            try
            {
                var response = endpoint.Get(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<ParticipantProgressResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public ParticipantScoresResponse? Scores(string participantId)
        {
            var path = "participant/{participant_id}/scores";
            path = path.Replace("{participant_id}", participantId);
            var request = new RestRequest(path);

            try
            {
                var response = endpoint.Get(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<ParticipantScoresResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public ParticipantListResponse? List(
            string projectId,
            int? limit = null,
            int? offset = null
        )
        {
            var path = "participant";
            var request = new RestRequest(path);

            request.AddQueryParameter("project_id", projectId);
            limit = limit == 0 ? 100 : limit;
            if (limit != null)
            {
                request.AddQueryParameter("limit", limit.Value);
            }
            if (offset != null)
            {
                request.AddQueryParameter("offset", offset.Value);
            }

            try
            {
                var response = endpoint.Get(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<ParticipantListResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public ParticipantCreateResponse? Create(ParticipantCreateRequest payload)
        {
            var path = "participant";
            var request = new RestRequest(path);

            request.AddJsonBody(JsonSerializer.Serialize(payload), contentType: "application/json");

            try
            {
                var response = endpoint.Put(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<ParticipantCreateResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public ParticipantReadResponse? Read(string participantId)
        {
            var path = "participant/{participant_id}";
            path = path.Replace("{participant_id}", participantId);
            var request = new RestRequest(path);

            try
            {
                var response = endpoint.Get(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<ParticipantReadResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public ParticipantUpdateResponse? Update(
            string participantId,
            ParticipantUpdateRequest payload
        )
        {
            var path = "participant/{participant_id}";
            path = path.Replace("{participant_id}", participantId);
            var request = new RestRequest(path);

            request.AddJsonBody(JsonSerializer.Serialize(payload), contentType: "application/json");

            try
            {
                var response = endpoint.Post(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<ParticipantUpdateResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public ParticipantDeleteResponse? Delete(string participantId)
        {
            var path = "participant/{participant_id}";
            path = path.Replace("{participant_id}", participantId);
            var request = new RestRequest(path);

            try
            {
                var response = endpoint.Delete(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<ParticipantDeleteResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }
    }

    public struct ScoreboardResource
    {
        private readonly RestClient endpoint;

        public ScoreboardResource(RestClient endpoint)
        {
            this.endpoint = endpoint;
        }

        public ScoreboardScoreResponse? Record(string scoreboardId, ScoreboardScoreRequest payload)
        {
            var path = "scoreboard/{scoreboard_id}/score";
            path = path.Replace("{scoreboard_id}", scoreboardId);
            var request = new RestRequest(path);

            request.AddJsonBody(JsonSerializer.Serialize(payload), contentType: "application/json");

            try
            {
                var response = endpoint.Put(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<ScoreboardScoreResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public ScoreboardScoresResponse? Scores(
            string scoreboardId,
            DateTime? from = null,
            DateTime? to = null
        )
        {
            var path = "scoreboard/{scoreboard_id}/scores";
            path = path.Replace("{scoreboard_id}", scoreboardId);
            var request = new RestRequest(path);

            if (from != null)
            {
                request.AddQueryParameter("from", from.Value);
            }
            if (to != null)
            {
                request.AddQueryParameter("to", to.Value);
            }

            try
            {
                var response = endpoint.Get(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<ScoreboardScoresResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public ScoreboardListResponse? List(string projectId, int? limit = null, int? offset = null)
        {
            var path = "scoreboard";
            var request = new RestRequest(path);

            request.AddQueryParameter("project_id", projectId);
            limit = limit == 0 ? 100 : limit;
            if (limit != null)
            {
                request.AddQueryParameter("limit", limit.Value);
            }
            if (offset != null)
            {
                request.AddQueryParameter("offset", offset.Value);
            }

            try
            {
                var response = endpoint.Get(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<ScoreboardListResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public ScoreboardCreateResponse? Create(ScoreboardCreateRequest payload)
        {
            var path = "scoreboard";
            var request = new RestRequest(path);

            request.AddJsonBody(JsonSerializer.Serialize(payload), contentType: "application/json");

            try
            {
                var response = endpoint.Put(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<ScoreboardCreateResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public ScoreboardReadResponse? Read(string scoreboardId)
        {
            var path = "scoreboard/{scoreboard_id}";
            path = path.Replace("{scoreboard_id}", scoreboardId);
            var request = new RestRequest(path);

            try
            {
                var response = endpoint.Get(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<ScoreboardReadResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public ScoreboardUpdateResponse? Update(
            string scoreboardId,
            ScoreboardUpdateRequest payload
        )
        {
            var path = "scoreboard/{scoreboard_id}";
            path = path.Replace("{scoreboard_id}", scoreboardId);
            var request = new RestRequest(path);

            request.AddJsonBody(JsonSerializer.Serialize(payload), contentType: "application/json");

            try
            {
                var response = endpoint.Post(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<ScoreboardUpdateResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }

        public ScoreboardDeleteResponse? Delete(string scoreboardId)
        {
            var path = "scoreboard/{scoreboard_id}";
            path = path.Replace("{scoreboard_id}", scoreboardId);
            var request = new RestRequest(path);

            try
            {
                var response = endpoint.Delete(request);
                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<ScoreboardDeleteResponse>(
                        response.Content ?? ""
                    );
                }
            }
            catch (HttpRequestException exc)
            {
                Console.WriteLine(exc.StatusCode);
                Console.WriteLine(exc.Message);
            }
            return null;
        }
    }
}

namespace Vements.API
{
    public record struct Contact
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }

        public Contact(string name, string email, string url)
        {
            this.name = name;
            this.email = email;
            this.url = url;
        }

        public Contact()
            : this("Vements Support Contact", "https://vements.io", "support@vements.io") { }
    };

    public record struct License
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }

        public License(string name, string url)
        {
            this.name = name;
            this.url = url;
        }

        public License()
            : this("MIT", "https://opensource.org/license/mit/") { }
    }

    public record struct ExternalDocs
    {
        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }

        public ExternalDocs(string description, string url)
        {
            this.description = description;
            this.url = url;
        }

        public ExternalDocs()
            : this("Vements REST API Documentation", "https://vements.io/docs") { }
    };

    public record struct Server(
        [property: JsonPropertyName("url")] string url,
        [property: JsonPropertyName("description")] string description,
        [property: JsonPropertyName("variables")] Dictionary<string, string> variables,
        [property: JsonPropertyName("tags")] List<string> tags
    );

    public record struct Config
    {
        [JsonPropertyName("title")]
        public string title { get; set; }

        [JsonPropertyName("version")]
        public string version { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("termsOfService")]
        public string termsOfService { get; set; }

        [JsonPropertyName("contact")]
        public Contact contact { get; set; }

        [JsonPropertyName("license")]
        public License license { get; set; }

        [JsonPropertyName("externalDocs")]
        public ExternalDocs externalDocs { get; set; }

        [JsonPropertyName("servers")]
        public List<Server> servers { get; set; }

        public Config(
            string title,
            string version,
            string description,
            string termsOfService,
            Contact contact,
            License license,
            ExternalDocs externalDocs,
            List<Server> servers
        )
        {
            this.title = title;
            this.version = version;
            this.description = description;
            this.termsOfService = termsOfService;
            this.contact = contact;
            this.license = license;
            this.externalDocs = externalDocs;
            this.servers = servers;
        }

        public Config()
            : this(
                "Vements REST API",
                "1.0.3",
                "This specification describes the Vements REST API, its endpoints, and  the data structures used to communicate with it.",
                "https://vements.io/terms",
                new Contact(),
                new License(),
                new ExternalDocs(),
                new List<Server>
                {
                    new Server(
                        "https://a.vements.io/{basePath}",
                        "Production Server",
                        new Dictionary<string, string> { ["basePath"] = "api/rest/v1.0.3/", },
                        new List<string> { "production", }
                    ),
                    new Server(
                        "http://api.localtest.me/{basePath}",
                        "Development Server (Host)",
                        new Dictionary<string, string> { ["basePath"] = "api/rest/v1.0.3/", },
                        new List<string> { "development", "host", "full", }
                    ),
                    new Server(
                        "http://localhost:9000/{basePath}",
                        "Development Server (Host Substitute)",
                        new Dictionary<string, string> { ["basePath"] = "api/rest/v1.0.3/", },
                        new List<string> { "development", "host", "substitute", }
                    ),
                    new Server(
                        "http://api-server-a:8080/{basePath}",
                        "Development Server (Container)",
                        new Dictionary<string, string> { ["basePath"] = "api/rest/v1.0.3/", },
                        new List<string> { "development", "container", "full", }
                    ),
                    new Server(
                        "http://substitute-server:9000/{basePath}",
                        "Development Server (Container Substitute)",
                        new Dictionary<string, string> { ["basePath"] = "api/rest/v1.0.3/", },
                        new List<string> { "development", "container", "substitute", }
                    ),
                }
            ) { }

        public string? serverUrl(List<string> tags)
        {
            foreach (var server in servers)
            {
                var matches = 0;
                foreach (var match in tags)
                {
                    foreach (var tag in server.tags)
                    {
                        if (tag == match)
                        {
                            matches = matches + 1;
                        }
                    }
                }
                if (matches >= tags.Count)
                {
                    var url = server.url;
                    foreach (var key in server.variables.Keys)
                    {
                        url = url.Replace("{" + key + "}", server.variables[key]);
                    }
                    return url;
                }
            }
            return null;
        }
    };
}

namespace Vements.API
{
    public record struct User(
        [property: JsonPropertyName("user_id")] string userId,
        [property: JsonPropertyName("email")] string email,
        [property: JsonPropertyName("display")] string display,
        [property: JsonPropertyName("created")] DateTime created,
        [property: JsonPropertyName("updated")] DateTime updated
    );

    public record struct Project(
        [property: JsonPropertyName("project_id")] string projectId,
        [property: JsonPropertyName("user_id")] string userId,
        [property: JsonPropertyName("display")] string display,
        [property: JsonPropertyName("created")] DateTime created,
        [property: JsonPropertyName("updated")] DateTime updated,
        [property: JsonPropertyName("extra")] object? extra
    );

    public record struct ApiKey(
        [property: JsonPropertyName("api_key_id")] string apiKeyId,
        [property: JsonPropertyName("project_id")] string projectId,
        [property: JsonPropertyName("display")] string display,
        [property: JsonPropertyName("capability")] string capability,
        [property: JsonPropertyName("deactivated")] DateTime? deactivated,
        [property: JsonPropertyName("last_used")] DateTime? lastUsed,
        [property: JsonPropertyName("created")] DateTime created,
        [property: JsonPropertyName("updated")] DateTime updated
    );

    public record struct Achievement(
        [property: JsonPropertyName("achievement_id")] string achievementId,
        [property: JsonPropertyName("project_id")] string projectId,
        [property: JsonPropertyName("display")] string display,
        [property: JsonPropertyName("goal")] int goal,
        [property: JsonPropertyName("repeats")] int repeats,
        [property: JsonPropertyName("locked_image")] string? lockedImage,
        [property: JsonPropertyName("unlocked_image")] string? unlockedImage,
        [property: JsonPropertyName("position")] int position,
        [property: JsonPropertyName("public")] bool public_,
        [property: JsonPropertyName("created")] DateTime created,
        [property: JsonPropertyName("updated")] DateTime updated,
        [property: JsonPropertyName("extra")] object? extra
    );

    public record struct Participant(
        [property: JsonPropertyName("participant_id")] string participantId,
        [property: JsonPropertyName("project_id")] string projectId,
        [property: JsonPropertyName("display")] string display,
        [property: JsonPropertyName("external_id")] string externalId,
        [property: JsonPropertyName("image")] string? image,
        [property: JsonPropertyName("created")] DateTime created,
        [property: JsonPropertyName("updated")] DateTime updated,
        [property: JsonPropertyName("extra")] object? extra
    );

    public record struct Scoreboard(
        [property: JsonPropertyName("scoreboard_id")] string scoreboardId,
        [property: JsonPropertyName("project_id")] string projectId,
        [property: JsonPropertyName("display")] string display,
        [property: JsonPropertyName("rank_dir")] string rankDir,
        [property: JsonPropertyName("public")] bool public_,
        [property: JsonPropertyName("created")] DateTime created,
        [property: JsonPropertyName("updated")] DateTime updated,
        [property: JsonPropertyName("extra")] object? extra
    );

    public record struct Progress(
        [property: JsonPropertyName("progress_id")] int progressId,
        [property: JsonPropertyName("achievement_id")] string achievementId,
        [property: JsonPropertyName("participant_id")] string participantId,
        [property: JsonPropertyName("value")] int value,
        [property: JsonPropertyName("recorded")] DateTime? recorded
    );

    public record struct Score(
        [property: JsonPropertyName("score_id")] int scoreId,
        [property: JsonPropertyName("scoreboard_id")] string scoreboardId,
        [property: JsonPropertyName("participant_id")] string participantId,
        [property: JsonPropertyName("value")] int value,
        [property: JsonPropertyName("recorded")] DateTime? recorded
    );

    public record struct AchievementLeaderboardItem(
        [property: JsonPropertyName("participant")] Participant participant,
        [property: JsonPropertyName("progress")] int progress,
        [property: JsonPropertyName("iterations")] int iterations
    );

    public record struct ParticipantProgressItem(
        [property: JsonPropertyName("achievement")] Achievement achievement,
        [property: JsonPropertyName("progress")] int progress,
        [property: JsonPropertyName("iterations")] int iterations
    );

    public record struct ParticipantScoreItem(
        [property: JsonPropertyName("scoreboard")] Scoreboard scoreboard,
        [property: JsonPropertyName("rank")] int rank,
        [property: JsonPropertyName("total")] int total
    );

    public record struct ScoreboardScoreItem(
        [property: JsonPropertyName("participant_id")] string participantId,
        [property: JsonPropertyName("participant")] Participant participant,
        [property: JsonPropertyName("rank")] int rank,
        [property: JsonPropertyName("total")] int total
    );

    public record struct AchievementLeaderboardResponse(
        [property: JsonPropertyName("achievement_leaderboard")]
            List<AchievementLeaderboardItem> achievementLeaderboard
    );

    public record struct AchievementProgressResponse(
        [property: JsonPropertyName("insert_progress_one")] Progress insertProgressOne
    );

    public record struct ParticipantProgressResponse(
        [property: JsonPropertyName("participant_progress")]
            List<ParticipantProgressItem> participantProgress
    );

    public record struct ParticipantScoresResponse(
        [property: JsonPropertyName("participant_scores")]
            List<ParticipantScoreItem> participantScores
    );

    public record struct ScoreboardScoreResponse(
        [property: JsonPropertyName("insert_score_one")] Score insertScoreOne
    );

    public record struct ScoreboardScoresResponse(
        [property: JsonPropertyName("scoreboard_scores")] List<ScoreboardScoreItem> scoreboardScores
    );

    public record struct AchievementProgressRequest(
        [property: JsonPropertyName("participant_id")] string participantId,
        [property: JsonPropertyName("value")] int value,
        [property: JsonPropertyName("recorded")] DateTime? recorded
    );

    public record struct ScoreboardScoreRequest(
        [property: JsonPropertyName("participant_id")] string participantId,
        [property: JsonPropertyName("value")] int value,
        [property: JsonPropertyName("recorded")] DateTime? recorded
    );

    public record struct AchievementCreateRequest(
        [property: JsonPropertyName("project_id")] string projectId,
        [property: JsonPropertyName("display")] string display,
        [property: JsonPropertyName("goal")] int goal,
        [property: JsonPropertyName("repeats")] int repeats,
        [property: JsonPropertyName("locked_image")] string? lockedImage,
        [property: JsonPropertyName("unlocked_image")] string? unlockedImage,
        [property: JsonPropertyName("position")] int position,
        [property: JsonPropertyName("public")] bool public_,
        [property: JsonPropertyName("extra")] object? extra
    );

    public record struct AchievementCreateResponse(
        [property: JsonPropertyName("insert_achievement_one")] Achievement insertAchievementOne
    );

    public record struct AchievementReadResponse(
        [property: JsonPropertyName("achievement")] List<Achievement> achievement
    );

    public record struct AchievementUpdateRequest(
        [property: JsonPropertyName("display")] string display,
        [property: JsonPropertyName("goal")] int goal,
        [property: JsonPropertyName("repeats")] int repeats,
        [property: JsonPropertyName("locked_image")] string? lockedImage,
        [property: JsonPropertyName("unlocked_image")] string? unlockedImage,
        [property: JsonPropertyName("position")] int position,
        [property: JsonPropertyName("public")] bool public_,
        [property: JsonPropertyName("extra")] object? extra
    );

    public record struct AchievementUpdateResponse(
        [property: JsonPropertyName("update_achievement_by_pk")] Achievement updateAchievementByPk
    );

    public record struct AchievementDeleteResponse(
        [property: JsonPropertyName("delete_achievement_by_pk")] Achievement? deleteAchievementByPk
    );

    public record struct AchievementListResponse(
        [property: JsonPropertyName("achievement")] List<Achievement> achievement
    );

    public record struct ParticipantCreateRequest(
        [property: JsonPropertyName("project_id")] string projectId,
        [property: JsonPropertyName("display")] string display,
        [property: JsonPropertyName("external_id")] string externalId,
        [property: JsonPropertyName("image")] string? image,
        [property: JsonPropertyName("extra")] object? extra
    );

    public record struct ParticipantCreateResponse(
        [property: JsonPropertyName("insert_participant_one")] Participant insertParticipantOne
    );

    public record struct ParticipantReadResponse(
        [property: JsonPropertyName("participant")] List<Participant> participant
    );

    public record struct ParticipantUpdateRequest(
        [property: JsonPropertyName("display")] string display,
        [property: JsonPropertyName("external_id")] string externalId,
        [property: JsonPropertyName("image")] string? image,
        [property: JsonPropertyName("extra")] object? extra
    );

    public record struct ParticipantUpdateResponse(
        [property: JsonPropertyName("update_participant_by_pk")] Participant updateParticipantByPk
    );

    public record struct ParticipantDeleteResponse(
        [property: JsonPropertyName("delete_participant_by_pk")] Participant? deleteParticipantByPk
    );

    public record struct ParticipantListResponse(
        [property: JsonPropertyName("participant")] List<Participant> participant
    );

    public record struct ScoreboardCreateRequest(
        [property: JsonPropertyName("project_id")] string projectId,
        [property: JsonPropertyName("display")] string display,
        [property: JsonPropertyName("rank_dir")] string rankDir,
        [property: JsonPropertyName("public")] bool public_,
        [property: JsonPropertyName("extra")] object? extra
    );

    public record struct ScoreboardCreateResponse(
        [property: JsonPropertyName("insert_scoreboard_one")] Scoreboard insertScoreboardOne
    );

    public record struct ScoreboardReadResponse(
        [property: JsonPropertyName("scoreboard")] List<Scoreboard> scoreboard
    );

    public record struct ScoreboardUpdateRequest(
        [property: JsonPropertyName("display")] string display,
        [property: JsonPropertyName("rank_dir")] string rankDir,
        [property: JsonPropertyName("public")] bool public_,
        [property: JsonPropertyName("extra")] object? extra
    );

    public record struct ScoreboardUpdateResponse(
        [property: JsonPropertyName("update_scoreboard_by_pk")] Scoreboard updateScoreboardByPk
    );

    public record struct ScoreboardDeleteResponse(
        [property: JsonPropertyName("delete_scoreboard_by_pk")] Scoreboard? deleteScoreboardByPk
    );

    public record struct ScoreboardListResponse(
        [property: JsonPropertyName("scoreboard")] List<Scoreboard> scoreboard
    );
}

