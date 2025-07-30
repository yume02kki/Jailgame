using System;

static class Terminal
{
    const String INFO_PHRASE = "You are in room {0}, These are the things you see: {1}";

    public static void renderPlayer(Player player)
    {
        String phrase = String.Format(INFO_PHRASE, player.getCurrentRoom(), player.getCurrentRoom() + "'s loot");
        Console.WriteLine(phrase);
    }
}
