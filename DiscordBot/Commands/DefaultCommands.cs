using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace DiscordBot.Commands;

public class DefaultCommands : BaseCommandModule
{
    [Command("ping")]
    private async Task Ping(CommandContext ctx)
    {
        DiscordMessage message = await ctx.RespondAsync("Ping...");
        await message.ModifyAsync($"Pong! {ctx.Client.Ping}ms.");
    }
}