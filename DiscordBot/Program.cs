using DiscordBot.Commands;
using DiscordBot.Events;
using dotenv.net;
using DSharpPlus;
using DSharpPlus.CommandsNext;
internal sealed class Program
{
    static async Task Main()
    {
        DotEnv.Load();
        await DiscordClientLogin();
    }

    private static async Task DiscordClientLogin()
    {
        DiscordConfiguration configuration = new DiscordConfiguration()
        {
            Intents = DiscordIntents.AllUnprivileged,
            Token = Environment.GetEnvironmentVariable("DISCORD_TOKEN"),
            MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Information,
            LogTimestampFormat = "dd-MM-yyyy HH:mm:ss"
        };
        DiscordClient discordClient = new DiscordClient(configuration);
        CommandsNextConfiguration commandsNextConfiguration = new CommandsNextConfiguration()
        {
            DmHelp = false,
            EnableDms = false,
            EnableDefaultHelp = false,
            StringPrefixes = new[] { "?" }
        };
        CommandsNextExtension commandsNext = discordClient.UseCommandsNext(commandsNextConfiguration);
        discordClient.GuildDownloadCompleted += ClientEvents.DiscordClientGuildDownloadCompleted;
        commandsNext.RegisterCommands<DefaultCommands>();
        await discordClient.ConnectAsync();
        await Task.Delay(-1);
    }
}