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
    public class Link
    {
        [Command("Link")]
        [Aliases("link")]

        public async Task LinkdeconvitedaUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("https://discordapp.com/invite/cPFBXDz");
        }
    }
}
