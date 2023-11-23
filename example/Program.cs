using Vements.API;

class Program
{
    static string ApiKey = "";
    static string ProjectId = "";
    static string ScoreboardId = "";

    static void Main(string[] args)
    {
        // Create a new client, which encapsulates the API connection.
        // You can do this once and reuse the object.
        var client = new Client(ApiKey);

        // Create a participant.  You can do this in your application as needed, 
        // for example, when a new player joins the game.
        var participantCreateResponse = client.participant.Create(
            new ParticipantCreateRequest(
                projectId: ProjectId,
                display: "Player 1",
                // This is the ID of the player in your application.  
                // It can be any string you want, but it must be unique 
                // within the project.
                externalId: "player-1",
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
        Random random = new Random();
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
        var scoreboardResponse = client.scoreboard.Scores(ScoreboardId, from: DateTime.Now.AddHours(-24), to: DateTime.Now);
        Console.WriteLine("Scoreboard: " + scoreboardResponse?.scoreboardScores);

        // Teardown: delete the participant.  You may or may not need to do this in your app.  We do it here to be tidy.
        var participantDeleteResponse = client.participant.Delete(participant?.participantId);
        Console.WriteLine("Participant Deleted: " + participantDeleteResponse);
    }
}
