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

using Bogus;
using RestSharp;
using Xunit;
using Vements.API;

namespace Vements.Test
{
    public class Database
    {
        [JsonPropertyName("user")]
        public List<User> User { get; set; }

        [JsonPropertyName("project")]
        public List<Project> Project { get; set; }

        [JsonPropertyName("api_key")]
        public List<ApiKey> ApiKey { get; set; }

        [JsonPropertyName("achievement")]
        public List<Achievement> Achievement { get; set; }

        [JsonPropertyName("participant")]
        public List<Participant> Participant { get; set; }

        [JsonPropertyName("scoreboard")]
        public List<Scoreboard> Scoreboard { get; set; }

        [JsonPropertyName("progress")]
        public List<Progress> Progress { get; set; }

        [JsonPropertyName("score")]
        public List<Score> Score { get; set; }

        public Database()
        {
            User = new List<User>();
            Project = new List<Project>();
            ApiKey = new List<ApiKey>();
            Achievement = new List<Achievement>();
            Participant = new List<Participant>();
            Scoreboard = new List<Scoreboard>();
            Progress = new List<Progress>();
            Score = new List<Score>();
        }
    }

    public class Setup
    {
        public Vements.API.ApiKey apiKey { get; set; }
        public Vements.API.Client client { get; set; }
        public Database db { get; set; }
        public Faker faker { get; set; }

        public Setup()
        {
            var tags = new List<string> { "development", "host", "substitute" };
            var c = new Vements.API.Client("no key needed", tags);
            var e = new RestClient(c.baseUrl);
            var r = e.Post(new RestRequest("-/database"));

            var database = JsonSerializer.Deserialize<Database>(r.Content ?? "");
            if (database == null)
            {
                throw new Exception("Could not deserialize database");
            }

            if (database.ApiKey == null || database.ApiKey.Count == 0)
            {
                throw new Exception("Could not find api keys");
            }

            ApiKey? key = null;
            foreach (var k in database.ApiKey)
            {
                if (k.capability == "rw")
                {
                    key = k;
                    break;
                }
            }
            if (key == null)
            {
                throw new Exception("Could not find rw api key");
            }

            apiKey = (ApiKey)key;
            client = new Vements.API.Client(apiKey.projectId + ":" + apiKey.apiKeyId, tags);
            db = database;
            faker = new Faker();
        }

        public string GetString(string key)
        {
            switch (key)
            {
                case "project_id":
                    return apiKey.projectId;
                default:
                    break;
            }

            if (key.EndsWith("_id"))
            {
                var random = new Random();
                var projectId = apiKey.projectId;
                switch (key)
                {
                    case "achievement_id":
                        var achievements = new List<Achievement>();
                        foreach (var item in db.Achievement)
                        {
                            if (item.projectId == projectId)
                            {
                                achievements.Add(item);
                            }
                        }
                        if (achievements.Count == 0)
                        {
                            break;
                        }
                        return achievements[random.Next(achievements.Count)].achievementId;
                    case "participant_id":
                        var participants = new List<Participant>();
                        foreach (var item in db.Participant)
                        {
                            if (item.projectId == projectId)
                            {
                                participants.Add(item);
                            }
                        }
                        if (participants.Count == 0)
                        {
                            break;
                        }
                        return participants[random.Next(participants.Count)].participantId;
                    case "scoreboard_id":
                        var scoreboards = new List<Scoreboard>();
                        foreach (var item in db.Scoreboard)
                        {
                            if (item.projectId == projectId)
                            {
                                scoreboards.Add(item);
                            }
                        }
                        if (scoreboards.Count == 0)
                        {
                            break;
                        }
                        return scoreboards[random.Next(scoreboards.Count)].scoreboardId;
                    default:
                        break;
                }
            }

            return "";
        }

        public int GetInt(string key)
        {
            switch (key)
            {
                case "limit":
                    return 100;
                case "offset":
                    return 0;
                case "value":
                    return 1;
                default:
                    return faker.Random.Int(0, 100);
            }
        }

        public DateTime GetDateTime(string key)
        {
            switch (key)
            {
                default:
                    return new DateTime();
            }
        }

        public bool GetBool(string key)
        {
            switch (key)
            {
                default:
                    return faker.Random.Bool();
            }
        }

        public object GetObject(string key)
        {
            switch (key)
            {
                default:
                    return new object();
            }
        }
    }

    public class HappyPathTests
    {
        [Fact]
        public void AchievementLeaderboardTest()
        {
            var setup = new Setup();
            var res = setup.client.achievement.Leaderboard(setup.GetString("achievement_id"));

            Assert.True(res != null);
        }

        [Fact]
        public void AchievementRecordTest()
        {
            var setup = new Setup();
            var res = setup.client.achievement.Record(
                setup.GetString("achievement_id"),
                new AchievementProgressRequest(
                    setup.GetString("participant_id"),
                    setup.GetInt("value"),
                    setup.GetDateTime("recorded")
                )
            );

            Assert.True(res != null);
        }

        [Fact]
        public void ParticipantProgressTest()
        {
            var setup = new Setup();
            var res = setup.client.participant.Progress(setup.GetString("participant_id"));

            Assert.True(res != null);
        }

        [Fact]
        public void ParticipantScoresTest()
        {
            var setup = new Setup();
            var res = setup.client.participant.Scores(setup.GetString("participant_id"));

            Assert.True(res != null);
        }

        [Fact]
        public void ScoreboardRecordTest()
        {
            var setup = new Setup();
            var res = setup.client.scoreboard.Record(
                setup.GetString("scoreboard_id"),
                new ScoreboardScoreRequest(
                    setup.GetString("participant_id"),
                    setup.GetInt("value"),
                    setup.GetDateTime("recorded")
                )
            );

            Assert.True(res != null);
        }

        [Fact]
        public void ScoreboardScoresTest()
        {
            var setup = new Setup();
            var res = setup.client.scoreboard.Scores(
                setup.GetString("scoreboard_id"),
                setup.GetDateTime("from"),
                setup.GetDateTime("to")
            );

            Assert.True(res != null);
        }

        [Fact]
        public void AchievementListTest()
        {
            var setup = new Setup();
            var res = setup.client.achievement.List(
                setup.GetString("project_id"),
                setup.GetInt("limit"),
                setup.GetInt("offset")
            );

            Assert.True(res != null);
        }

        [Fact]
        public void AchievementCreateTest()
        {
            var setup = new Setup();
            var res = setup.client.achievement.Create(
                new AchievementCreateRequest(
                    setup.GetString("project_id"),
                    setup.GetString("display"),
                    setup.GetInt("goal"),
                    setup.GetInt("repeats"),
                    setup.GetString("locked_image"),
                    setup.GetString("unlocked_image"),
                    setup.GetInt("position"),
                    setup.GetBool("public"),
                    setup.GetObject("extra")
                )
            );

            Assert.True(res != null);
        }

        [Fact]
        public void AchievementReadTest()
        {
            var setup = new Setup();
            var res = setup.client.achievement.Read(setup.GetString("achievement_id"));

            Assert.True(res != null);
        }

        [Fact]
        public void AchievementUpdateTest()
        {
            var setup = new Setup();
            var res = setup.client.achievement.Update(
                setup.GetString("achievement_id"),
                new AchievementUpdateRequest(
                    setup.GetString("display"),
                    setup.GetInt("goal"),
                    setup.GetInt("repeats"),
                    setup.GetString("locked_image"),
                    setup.GetString("unlocked_image"),
                    setup.GetInt("position"),
                    setup.GetBool("public"),
                    setup.GetObject("extra")
                )
            );

            Assert.True(res != null);
        }

        [Fact]
        public void AchievementDeleteTest()
        {
            var setup = new Setup();
            var res = setup.client.achievement.Delete(setup.GetString("achievement_id"));

            Assert.True(res != null);
        }

        [Fact]
        public void ParticipantListTest()
        {
            var setup = new Setup();
            var res = setup.client.participant.List(
                setup.GetString("project_id"),
                setup.GetInt("limit"),
                setup.GetInt("offset")
            );

            Assert.True(res != null);
        }

        [Fact]
        public void ParticipantCreateTest()
        {
            var setup = new Setup();
            var res = setup.client.participant.Create(
                new ParticipantCreateRequest(
                    setup.GetString("project_id"),
                    setup.GetString("display"),
                    setup.GetString("external_id"),
                    setup.GetString("image"),
                    setup.GetObject("extra")
                )
            );

            Assert.True(res != null);
        }

        [Fact]
        public void ParticipantReadTest()
        {
            var setup = new Setup();
            var res = setup.client.participant.Read(setup.GetString("participant_id"));

            Assert.True(res != null);
        }

        [Fact]
        public void ParticipantUpdateTest()
        {
            var setup = new Setup();
            var res = setup.client.participant.Update(
                setup.GetString("participant_id"),
                new ParticipantUpdateRequest(
                    setup.GetString("display"),
                    setup.GetString("external_id"),
                    setup.GetString("image"),
                    setup.GetObject("extra")
                )
            );

            Assert.True(res != null);
        }

        [Fact]
        public void ParticipantDeleteTest()
        {
            var setup = new Setup();
            var res = setup.client.participant.Delete(setup.GetString("participant_id"));

            Assert.True(res != null);
        }

        [Fact]
        public void ScoreboardListTest()
        {
            var setup = new Setup();
            var res = setup.client.scoreboard.List(
                setup.GetString("project_id"),
                setup.GetInt("limit"),
                setup.GetInt("offset")
            );

            Assert.True(res != null);
        }

        [Fact]
        public void ScoreboardCreateTest()
        {
            var setup = new Setup();
            var res = setup.client.scoreboard.Create(
                new ScoreboardCreateRequest(
                    setup.GetString("project_id"),
                    setup.GetString("display"),
                    setup.GetString("rank_dir"),
                    setup.GetBool("public"),
                    setup.GetObject("extra")
                )
            );

            Assert.True(res != null);
        }

        [Fact]
        public void ScoreboardReadTest()
        {
            var setup = new Setup();
            var res = setup.client.scoreboard.Read(setup.GetString("scoreboard_id"));

            Assert.True(res != null);
        }

        [Fact]
        public void ScoreboardUpdateTest()
        {
            var setup = new Setup();
            var res = setup.client.scoreboard.Update(
                setup.GetString("scoreboard_id"),
                new ScoreboardUpdateRequest(
                    setup.GetString("display"),
                    setup.GetString("rank_dir"),
                    setup.GetBool("public"),
                    setup.GetObject("extra")
                )
            );

            Assert.True(res != null);
        }

        [Fact]
        public void ScoreboardDeleteTest()
        {
            var setup = new Setup();
            var res = setup.client.scoreboard.Delete(setup.GetString("scoreboard_id"));

            Assert.True(res != null);
        }
    }
}

