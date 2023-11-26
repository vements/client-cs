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

using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;

using McMaster.Extensions.CommandLineUtils;

namespace Vements.CLI
{
    // cli app
    [Command(Name = "vements", Description = "Achievements and scoreboards for everyone")]
    [Subcommand(typeof(ApiVersion))]
    [Subcommand(typeof(ClientVersion))]
    [Subcommand(typeof(AchievementCommand))]
    [Subcommand(typeof(ParticipantCommand))]
    [Subcommand(typeof(ScoreboardCommand))]
    public class App : Command
    {
        public void OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();
            Environment.Exit(1);
        }

        public static void Main(string[] args)
        {
            CommandLineApplication.Execute<App>(args);
        }
    }

    public class Command
    {
        [Option("--api-key", Description = "API Key")]
        public string? ApiKeyOption { get; set; }

        [Option("--verbose", Description = "Verbose output")]
        public bool Verbose { get; }

        public string ApiKey
        {
            get
            {
                if (ApiKeyOption == null || ApiKeyOption == "")
                {
                    var v = Environment.GetEnvironmentVariable("API_KEY");
                    if (v == null || v == "")
                    {
                        Console.WriteLine(
                            $"No API key.  Pass API_KEY from the environment or --api-key on the command line."
                        );
                        Environment.Exit(1);
                    }
                    ApiKeyOption = v;
                }
                return ApiKeyOption;
            }
        }

        public Vements.API.Client client
        {
            get { return new Vements.API.Client(ApiKey); }
        }

        public JsonSerializerOptions jsonSerializerOptions
        {
            get
            {
                var options = new JsonSerializerOptions { WriteIndented = Verbose, };
                return options;
            }
        }

        public object asObject(string value)
        {
            return JsonSerializer.Deserialize<ExpandoObject>(value) ?? new object();
        }
    }

    [Command("api-version", Description = "Show API version")]
    class ApiVersion : Command
    {
        private string version = "1.0.3";

        public void OnExecute(CommandLineApplication app)
        {
            Console.WriteLine(version);
        }
    }

    [Command("client-version", Description = "Show client library version")]
    class ClientVersion : Command
    {
        private string version = "0.0.1";

        public void OnExecute(CommandLineApplication app)
        {
            Console.WriteLine(version);
        }
    }

    /*

    Top-level "achievement" command and its subcommands

    */
    [Command("achievement", Description = "Achievement operations")]
    [Subcommand(typeof(Leaderboard))]
    [Subcommand(typeof(Record))]
    [Subcommand(typeof(List))]
    [Subcommand(typeof(Create))]
    [Subcommand(typeof(Read))]
    [Subcommand(typeof(Update))]
    [Subcommand(typeof(Delete))]
    class AchievementCommand : Command
    {
        public void OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();
            Environment.Exit(1);
        }

        /*

        achievement "leaderboard" subcommand

        */
        [Command("Leaderboard", Description = "Achievement leaderboard")]
        public class Leaderboard : Command
        {
            [Required]
            [Option("--achievement-id", Description = "achievement id")]
            public required string achievementId { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.achievement.Leaderboard(achievementId);
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Achievement.Leaderboard.");
                }
            }
        }

        /*

        achievement "record" subcommand

        */
        [Command("Record", Description = "Record achievement progress")]
        public class Record : Command
        {
            [Required]
            [Option("--achievement-id", Description = "achievement id")]
            public required string achievementId { get; set; }

            [Required]
            [Option(
                "--participant-id",
                CommandOptionType.SingleValue,
                Description = "participant id"
            )]
            public required string participantId { get; set; }

            [Required]
            [Option("--value", CommandOptionType.SingleValue, Description = "value")]
            public required int value { get; set; }

            [Required]
            [Option("--recorded", CommandOptionType.SingleValue, Description = "recorded")]
            public required DateTime recorded { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.achievement.Record(
                    achievementId,
                    new Vements.API.AchievementProgressRequest(participantId, value, recorded)
                );
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Achievement.Record.");
                }
            }
        }

        /*

        achievement "list" subcommand

        */
        [Command("List", Description = "List achievements")]
        public class List : Command
        {
            [Required]
            [Option("--project-id", Description = "project id")]
            public required string projectId { get; set; }

            [Required]
            [Option("--limit", Description = "limit")]
            public required int limit { get; set; }

            [Required]
            [Option("--offset", Description = "offset")]
            public required int offset { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.achievement.List(projectId, limit, offset);
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Achievement.List.");
                }
            }
        }

        /*

        achievement "create" subcommand

        */
        [Command("Create", Description = "Create achievement")]
        public class Create : Command
        {
            [Required]
            [Option("--project-id", CommandOptionType.SingleValue, Description = "project id")]
            public required string projectId { get; set; }

            [Required]
            [Option("--display", CommandOptionType.SingleValue, Description = "display")]
            public required string display { get; set; }

            [Required]
            [Option("--goal", CommandOptionType.SingleValue, Description = "goal")]
            public required int goal { get; set; }

            [Required]
            [Option("--repeats", CommandOptionType.SingleValue, Description = "repeats")]
            public required int repeats { get; set; }

            [Required]
            [Option("--locked-image", CommandOptionType.SingleValue, Description = "locked image")]
            public required string lockedImage { get; set; }

            [Required]
            [Option(
                "--unlocked-image",
                CommandOptionType.SingleValue,
                Description = "unlocked image"
            )]
            public required string unlockedImage { get; set; }

            [Required]
            [Option("--position", CommandOptionType.SingleValue, Description = "position")]
            public required int position { get; set; }

            [Required]
            [Option("--public", CommandOptionType.SingleValue, Description = "public")]
            public required bool public_ { get; set; }

            [Required]
            [Option("--extra", CommandOptionType.SingleValue, Description = "extra")]
            public required string extra { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.achievement.Create(
                    new Vements.API.AchievementCreateRequest(
                        projectId,
                        display,
                        goal,
                        repeats,
                        lockedImage,
                        unlockedImage,
                        position,
                        public_,
                        asObject(extra)
                    )
                );
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Achievement.Create.");
                }
            }
        }

        /*

        achievement "read" subcommand

        */
        [Command("Read", Description = "Read achievement")]
        public class Read : Command
        {
            [Required]
            [Option("--achievement-id", Description = "achievement id")]
            public required string achievementId { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.achievement.Read(achievementId);
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Achievement.Read.");
                }
            }
        }

        /*

        achievement "update" subcommand

        */
        [Command("Update", Description = "Update achievement")]
        public class Update : Command
        {
            [Required]
            [Option("--achievement-id", Description = "achievement id")]
            public required string achievementId { get; set; }

            [Required]
            [Option("--display", CommandOptionType.SingleValue, Description = "display")]
            public required string display { get; set; }

            [Required]
            [Option("--goal", CommandOptionType.SingleValue, Description = "goal")]
            public required int goal { get; set; }

            [Required]
            [Option("--repeats", CommandOptionType.SingleValue, Description = "repeats")]
            public required int repeats { get; set; }

            [Required]
            [Option("--locked-image", CommandOptionType.SingleValue, Description = "locked image")]
            public required string lockedImage { get; set; }

            [Required]
            [Option(
                "--unlocked-image",
                CommandOptionType.SingleValue,
                Description = "unlocked image"
            )]
            public required string unlockedImage { get; set; }

            [Required]
            [Option("--position", CommandOptionType.SingleValue, Description = "position")]
            public required int position { get; set; }

            [Required]
            [Option("--public", CommandOptionType.SingleValue, Description = "public")]
            public required bool public_ { get; set; }

            [Required]
            [Option("--extra", CommandOptionType.SingleValue, Description = "extra")]
            public required string extra { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.achievement.Update(
                    achievementId,
                    new Vements.API.AchievementUpdateRequest(
                        display,
                        goal,
                        repeats,
                        lockedImage,
                        unlockedImage,
                        position,
                        public_,
                        asObject(extra)
                    )
                );
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Achievement.Update.");
                }
            }
        }

        /*

        achievement "delete" subcommand

        */
        [Command("Delete", Description = "Delete achievement by id.")]
        public class Delete : Command
        {
            [Required]
            [Option("--achievement-id", Description = "achievement id")]
            public required string achievementId { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.achievement.Delete(achievementId);
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Achievement.Delete.");
                }
            }
        }
    }

    /*

    Top-level "participant" command and its subcommands

    */
    [Command("participant", Description = "Participant operations")]
    [Subcommand(typeof(Progress))]
    [Subcommand(typeof(Scores))]
    [Subcommand(typeof(List))]
    [Subcommand(typeof(Create))]
    [Subcommand(typeof(Read))]
    [Subcommand(typeof(Update))]
    [Subcommand(typeof(Delete))]
    class ParticipantCommand : Command
    {
        public void OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();
            Environment.Exit(1);
        }

        /*

        participant "progress" subcommand

        */
        [Command("Progress", Description = "Participant progress")]
        public class Progress : Command
        {
            [Required]
            [Option("--participant-id", Description = "participant id")]
            public required string participantId { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.participant.Progress(participantId);
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Participant.Progress.");
                }
            }
        }

        /*

        participant "scores" subcommand

        */
        [Command("Scores", Description = "Participant scores")]
        public class Scores : Command
        {
            [Required]
            [Option("--participant-id", Description = "participant id")]
            public required string participantId { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.participant.Scores(participantId);
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Participant.Scores.");
                }
            }
        }

        /*

        participant "list" subcommand

        */
        [Command("List", Description = "List participants")]
        public class List : Command
        {
            [Required]
            [Option("--project-id", Description = "project id")]
            public required string projectId { get; set; }

            [Required]
            [Option("--limit", Description = "limit")]
            public required int limit { get; set; }

            [Required]
            [Option("--offset", Description = "offset")]
            public required int offset { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.participant.List(projectId, limit, offset);
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Participant.List.");
                }
            }
        }

        /*

        participant "create" subcommand

        */
        [Command("Create", Description = "Create participant")]
        public class Create : Command
        {
            [Required]
            [Option("--project-id", CommandOptionType.SingleValue, Description = "project id")]
            public required string projectId { get; set; }

            [Required]
            [Option("--display", CommandOptionType.SingleValue, Description = "display")]
            public required string display { get; set; }

            [Required]
            [Option("--external-id", CommandOptionType.SingleValue, Description = "external id")]
            public required string externalId { get; set; }

            [Required]
            [Option("--image", CommandOptionType.SingleValue, Description = "image")]
            public required string image { get; set; }

            [Required]
            [Option("--extra", CommandOptionType.SingleValue, Description = "extra")]
            public required string extra { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.participant.Create(
                    new Vements.API.ParticipantCreateRequest(
                        projectId,
                        display,
                        externalId,
                        image,
                        asObject(extra)
                    )
                );
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Participant.Create.");
                }
            }
        }

        /*

        participant "read" subcommand

        */
        [Command("Read", Description = "Read participant")]
        public class Read : Command
        {
            [Required]
            [Option("--participant-id", Description = "participant id")]
            public required string participantId { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.participant.Read(participantId);
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Participant.Read.");
                }
            }
        }

        /*

        participant "update" subcommand

        */
        [Command("Update", Description = "Update participant")]
        public class Update : Command
        {
            [Required]
            [Option("--participant-id", Description = "participant id")]
            public required string participantId { get; set; }

            [Required]
            [Option("--display", CommandOptionType.SingleValue, Description = "display")]
            public required string display { get; set; }

            [Required]
            [Option("--external-id", CommandOptionType.SingleValue, Description = "external id")]
            public required string externalId { get; set; }

            [Required]
            [Option("--image", CommandOptionType.SingleValue, Description = "image")]
            public required string image { get; set; }

            [Required]
            [Option("--extra", CommandOptionType.SingleValue, Description = "extra")]
            public required string extra { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.participant.Update(
                    participantId,
                    new Vements.API.ParticipantUpdateRequest(
                        display,
                        externalId,
                        image,
                        asObject(extra)
                    )
                );
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Participant.Update.");
                }
            }
        }

        /*

        participant "delete" subcommand

        */
        [Command("Delete", Description = "Delete participant by id.")]
        public class Delete : Command
        {
            [Required]
            [Option("--participant-id", Description = "participant id")]
            public required string participantId { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.participant.Delete(participantId);
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Participant.Delete.");
                }
            }
        }
    }

    /*

    Top-level "scoreboard" command and its subcommands

    */
    [Command("scoreboard", Description = "Scoreboard operations")]
    [Subcommand(typeof(Record))]
    [Subcommand(typeof(Scores))]
    [Subcommand(typeof(List))]
    [Subcommand(typeof(Create))]
    [Subcommand(typeof(Read))]
    [Subcommand(typeof(Update))]
    [Subcommand(typeof(Delete))]
    class ScoreboardCommand : Command
    {
        public void OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();
            Environment.Exit(1);
        }

        /*

        scoreboard "record" subcommand

        */
        [Command("Record", Description = "Record a scoreboard score")]
        public class Record : Command
        {
            [Required]
            [Option("--scoreboard-id", Description = "scoreboard id")]
            public required string scoreboardId { get; set; }

            [Required]
            [Option(
                "--participant-id",
                CommandOptionType.SingleValue,
                Description = "participant id"
            )]
            public required string participantId { get; set; }

            [Required]
            [Option("--value", CommandOptionType.SingleValue, Description = "value")]
            public required int value { get; set; }

            [Required]
            [Option("--recorded", CommandOptionType.SingleValue, Description = "recorded")]
            public required DateTime recorded { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.scoreboard.Record(
                    scoreboardId,
                    new Vements.API.ScoreboardScoreRequest(participantId, value, recorded)
                );
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Scoreboard.Record.");
                }
            }
        }

        /*

        scoreboard "scores" subcommand

        */
        [Command("Scores", Description = "Scoreboard scores")]
        public class Scores : Command
        {
            [Required]
            [Option("--scoreboard-id", Description = "scoreboard id")]
            public required string scoreboardId { get; set; }

            [Required]
            [Option("--from", Description = "from")]
            public required DateTime from { get; set; }

            [Required]
            [Option("--to", Description = "to")]
            public required DateTime to { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.scoreboard.Scores(scoreboardId, from, to);
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Scoreboard.Scores.");
                }
            }
        }

        /*

        scoreboard "list" subcommand

        */
        [Command("List", Description = "List scoreboards")]
        public class List : Command
        {
            [Required]
            [Option("--project-id", Description = "project id")]
            public required string projectId { get; set; }

            [Required]
            [Option("--limit", Description = "limit")]
            public required int limit { get; set; }

            [Required]
            [Option("--offset", Description = "offset")]
            public required int offset { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.scoreboard.List(projectId, limit, offset);
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Scoreboard.List.");
                }
            }
        }

        /*

        scoreboard "create" subcommand

        */
        [Command("Create", Description = "Create scoreboard")]
        public class Create : Command
        {
            [Required]
            [Option("--project-id", CommandOptionType.SingleValue, Description = "project id")]
            public required string projectId { get; set; }

            [Required]
            [Option("--display", CommandOptionType.SingleValue, Description = "display")]
            public required string display { get; set; }

            [Required]
            [Option("--rank-dir", CommandOptionType.SingleValue, Description = "rank dir")]
            public required string rankDir { get; set; }

            [Required]
            [Option("--public", CommandOptionType.SingleValue, Description = "public")]
            public required bool public_ { get; set; }

            [Required]
            [Option("--extra", CommandOptionType.SingleValue, Description = "extra")]
            public required string extra { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.scoreboard.Create(
                    new Vements.API.ScoreboardCreateRequest(
                        projectId,
                        display,
                        rankDir,
                        public_,
                        asObject(extra)
                    )
                );
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Scoreboard.Create.");
                }
            }
        }

        /*

        scoreboard "read" subcommand

        */
        [Command("Read", Description = "Read scoreboard")]
        public class Read : Command
        {
            [Required]
            [Option("--scoreboard-id", Description = "scoreboard id")]
            public required string scoreboardId { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.scoreboard.Read(scoreboardId);
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Scoreboard.Read.");
                }
            }
        }

        /*

        scoreboard "update" subcommand

        */
        [Command("Update", Description = "Update scoreboard")]
        public class Update : Command
        {
            [Required]
            [Option("--scoreboard-id", Description = "scoreboard id")]
            public required string scoreboardId { get; set; }

            [Required]
            [Option("--display", CommandOptionType.SingleValue, Description = "display")]
            public required string display { get; set; }

            [Required]
            [Option("--rank-dir", CommandOptionType.SingleValue, Description = "rank dir")]
            public required string rankDir { get; set; }

            [Required]
            [Option("--public", CommandOptionType.SingleValue, Description = "public")]
            public required bool public_ { get; set; }

            [Required]
            [Option("--extra", CommandOptionType.SingleValue, Description = "extra")]
            public required string extra { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.scoreboard.Update(
                    scoreboardId,
                    new Vements.API.ScoreboardUpdateRequest(
                        display,
                        rankDir,
                        public_,
                        asObject(extra)
                    )
                );
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Scoreboard.Update.");
                }
            }
        }

        /*

        scoreboard "delete" subcommand

        */
        [Command("Delete", Description = "Delete scoreboard by id.")]
        public class Delete : Command
        {
            [Required]
            [Option("--scoreboard-id", Description = "scoreboard id")]
            public required string scoreboardId { get; set; }

            public void OnExecute(CommandLineApplication app)
            {
                var result = client.scoreboard.Delete(scoreboardId);
                if (result != null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(result, jsonSerializerOptions));
                }
                else
                {
                    Console.Error.WriteLine("Error during Scoreboard.Delete.");
                }
            }
        }
    }
}

