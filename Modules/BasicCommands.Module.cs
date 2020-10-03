using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;

using DSharpPlus;

using System;
using System.Threading.Tasks;
using System.Linq;

public class BasicCommandsModule : IModule
{
    Logs log = new Logs();

    // Command: !qa:SetLogsChannel
    // Description: Sets the log channel for the bot to 
    // write the logs to
    [Command("SetLogsChannel")]
    [Description("Sets the log channel for the server")]
    [RequirePermissions(Permissions.Administrator)]
    public async Task SetLogschannel(CommandContext context)
    {
        Console.WriteLine("[info] Retreiving logs channel id and server id");
        log.LogChannelID = context.Channel.Id;
        Console.WriteLine("[info] Set channel ID to " + log.LogChannelID.ToString());
        log.ServerID = context.Guild.Id;
        Console.WriteLine("[info] Set Server ID to " + log.ServerID.ToString());
        log.SetLogs();
    }
}
