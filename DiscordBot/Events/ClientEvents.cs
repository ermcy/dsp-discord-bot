using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

namespace DiscordBot.Events
{
    public sealed class ClientEvents
    {
        private static readonly DiscordActivity discordActivity = new DiscordActivity()
        {
            ActivityType = ActivityType.Watching,
            Name = "for ?help"
        };
        public static async Task DiscordClientGuildDownloadCompleted(DiscordClient sender, GuildDownloadCompletedEventArgs e)
        {
            await sender.UpdateStatusAsync(discordActivity);
        }
    }
}
