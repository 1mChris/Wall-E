using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class IntroduçãoDiscord
    {
        [Command("Discord")]
        [Aliases("discord")]

        public async Task IntroDiscord(CommandContext ctx)
        {
            await ctx.RespondAsync("https://youtu.be/8aydobOKeA0");
        }
    }
}
