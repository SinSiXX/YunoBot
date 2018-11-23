﻿using System.Threading.Tasks;
using Discord.Commands;
using Yuno.Data.Core.Interfaces;
using Yuno.Logic;
using Yuno.Main.Extentions;

namespace Yuno.Main.Commands.Modules
{
    [Group("help")]
    public class HelpModule : ModuleBase<SocketCommandContext>
    {
        [Priority(-1)]
        [Command]
        public async Task DefaultHelp([Remainder]string message = null)
        {
            var prefix = CommandSettings.Load(Context.Guild.Id).Prefix;
            if (!string.IsNullOrEmpty(message))
            {
                await ReplyAsync("There is no advanced information for that command (yet).");
                return;
            }

            var ember = EmbedExtention.CreateEmbed("Help", $@"Here is a list of commands you can use.

__**General commands**__
{prefix}help (command) - Show advanced help for a command.
{prefix}pick (option1|option2|etc) - Select a random item from the options that are separated with |.
{prefix}birthday (username) - Sing a song for a happy fellow.
{prefix}kill (username) - Make me kill that user.

__praise__
{prefix}praise (username) - Send a positive message to that user.
{prefix}praise someone - Send a positive message to a random person.
{prefix}praise everyone - Send a positive message to everyone.
{prefix}praise god - Send a positive message to god.
{prefix}praise satan - Send a positive message to satan.
{prefix}praise wizard - Send a positive message to the wizard.

__music__
{prefix}music play (video url) - Add a song to the queue.
{prefix}music play (playlist url) - Add all songs in the playlist to the queue..
{prefix}music play (name) - Search for a song by it's name and add it to the queue.
{prefix}music playing - Show what song is currently playing.
{prefix}music queue - List all the songs in the queue.
{prefix}music shuffle - Shuffle all the songs in the queue.
{prefix}music skip - Skip the song currently playing.
{prefix}music clear - Remove all songs from the queue.
{prefix}music stop - Stop playing music and remove all songs from the queue.

__**Admin commands**__
{prefix}announce (message) - Announce a message to all members of your server.

__prefix__
{prefix}prefix - Show the command prefix for this server.
{prefix}prefix set (new prefix) - Change the command prefix for this server.

I am constantly updated with new features so keep an eye on this page.");
            await ReplyAsync("", false, ember);
        }
        
        [Command("praise")]
        public async Task PHelpraise()
        {
            var prefix = CommandSettings.Load(Context.Guild.Id).Prefix;
            var embed = EmbedExtention.CreateEmbed("Help praise", $@"Here is more information about 'praise'.

{prefix}praise (username) - Send a positive message to that user.
{prefix}praise someone - Send a positive message to a random person.
{prefix}praise everyone - Send a positive message to everyone.
{prefix}praise god - Send a positive message to god.
{prefix}praise satan - Send a positive message to satan.
{prefix}praise wizard - Send a positive message to the wizard.");
            await ReplyAsync("", false, embed);
        }

        [Command("prefix")]
        public async Task HelpPrefix()
        {
            var prefix = CommandSettings.Load(Context.Guild.Id).Prefix;
            var embed = EmbedExtention.CreateEmbed("Help prefix", $@"Here is more information about 'prefix'.

{prefix}prefix - Show the command prefix for this server.
{prefix}prefix set (new prefix) - Change the command prefix for this server.");
            await ReplyAsync("", false, embed);
        }

        [Command("music")]
        public async Task HelpMusic()
        {
            var prefix = CommandSettings.Load(Context.Guild.Id).Prefix;
            var embed = EmbedExtention.CreateEmbed("Help music", $@"Here is more information about 'music'.

{prefix}music play (video url) - Add a song to the queue.
{prefix}music play (playlist url) - Add all songs in the playlist to the queue..
{prefix}music play (name) - Search for a song by it's name and add it to the queue.
{prefix}music playing - Show what song is currently playing.
{prefix}music queue - List all the songs in the queue.
{prefix}music shuffle - Shuffle all the songs in the queue.
{prefix}music skip - Skip the song currently playing.
{prefix}music clear - Remove all songs from the queue.
{prefix}music stop - Stop playing music and remove all songs from the queue.");
            await ReplyAsync("", false, embed);
        }
    }
}