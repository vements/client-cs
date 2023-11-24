using Vements.API;

class Program
{
    static string ApiKey = "";
    static string ProjectId = "";
    static string ScoreboardId = "";

    static void Main(string[] args)
    {
        Random random = new Random();
        var player = random.Next(1, 10000);

        // Create a new client, which encapsulates the API connection.
        // You can do this once and reuse the object.
        var client = new Client(ApiKey);

        // Create a participant.  You can do this in your application as needed, 
        // for example, when a new player joins the game.
        var participantCreateResponse = client.participant.Create(
            new ParticipantCreateRequest(
                projectId: ProjectId,
                display: $"Example Player {player}",
                // This is the ID of the player in your application.  
                // It can be any string you want, but it must be unique 
                // within the project.
                externalId: $"example player {player}",
                // This is the URL of the player's avatar image.  It can be any URL you want,
                // including a data URI.
                image: null,
                extra: null
            )
        );


        var participant = participantCreateResponse?.insertParticipantOne;
        Console.WriteLine("Participant Created: " + participant?.participantId);

        // Create scores for this new participant and scoreboard.  
        // You can do this in your application as the player plays the game.

        int i = 0;
        while (i < 5)
        {
            client.scoreboard.Record(
                ScoreboardId,
                new ScoreboardScoreRequest(
                    participantId: participant?.participantId,
                    value: random.Next(1, 100),
                    recorded: DateTime.Now
                )
            );

            i++;
        }

        // Read the scoreboard and show it.
        var scoreboardResponse = client.scoreboard.Scores(ScoreboardId);
        var scores = scoreboardResponse?.scoreboardScores;

        foreach (var score in scores) {
            Console.WriteLine($"Rank: {score.rank} Player: {score.participant.display} Total: {score.total}");
        }
    }
}
