using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;

using DSharpPlus;
using DSharpPlus.EventArgs;
using System;
using System.Threading.Tasks;
using System.Linq;


class Events
{
    public Events(DiscordClient client){
        _discord = client;
    }
    static public DiscordClient _discord { get; set; }
    public static async Task EventHandler(string[] args)
    {
        _discord.MessageCreated += async e =>
        {
            await e.Message.RespondAsync("Test");
        };
    }
}