﻿using Discord;
using Discord.Commands;
using Logic.Data;
using System.Threading.Tasks;

namespace Logic.Modules
{
    [Alias("pc")]
    [Group("permachannel")]
    [RequireUserPermission(GuildPermission.Administrator)]
    public class PermaChannelModule : ModuleBase<SocketCommandContext>
    {
        [Priority(-1)]
        [Command]
        public async Task DefaultPermaChannel()
        {
            await ReplyAsync(
                $@"The current perma channel icon for this server is '{AutoChannel.Load(Context.Guild.Id).GetPermaChannelIcon()}'.
You can check 'http://unicode.org/emoji/charts/full-emoji-list.html' for the icon to paste in the channel name.");
        }

        [Command("seticon")]
        public async Task PermaChannelSetIcon([Remainder] string message)
        {
            var persistence = AutoChannel.Load(Context.Guild.Id);
            if (message.StartsWith(persistence.GetAutoChannelIcon()))
            {
                await ReplyAsync("I am not able to use the same icon for both auto channels and perma channels.");
                return;
            }

            persistence.SetPermaChannelIcon(message);
            persistence.Save();
            await ReplyAsync($"The new perma channel icon for this server is '{persistence.GetPermaChannelIcon()}'");
        }
    }
}