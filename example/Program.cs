using Vements.API;

class Program
{
    static string ExampleApiKey = "";
    static string ExampleProjectId = "";

    static void Main(string[] args)
    {
        var client = new Client(ExampleApiKey);

        var participantCreateResponse = client.participant.Create(
            new ParticipantCreateRequest(
                projectId: ExampleProjectId,
                externalId: "player-1",
                display: "Player 12",
                image: "",
                extra: null
            )
        );

        var participant = participantCreateResponse?.insertParticipantOne;
        Console.WriteLine("New Participant Created: " + participant);

        var scoreboardCreateResponse = client.scoreboard.Create(
            new ScoreboardCreateRequest(
                projectId: ExampleProjectId,
                display: "Basically Exciting Scoreboard 2",
                rankDir: "asc",
                public_: true,
                extra: null
            )
        );

        var scoreboard = scoreboardCreateResponse?.insertScoreboardOne;
        Console.WriteLine("New Scoreboard Created: " + scoreboard);

        // Teardown
        var scoreboardDeleteResponse = client.scoreboard.Delete(scoreboard?.scoreboardId);
        Console.WriteLine("New Scoreboard Deleted: " + scoreboardDeleteResponse);
    }
}
