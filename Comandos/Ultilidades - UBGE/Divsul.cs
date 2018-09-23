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
    public class Divsul
    {
        [Command("Divsul")]
        [Aliases("divsul")]

        public async Task DivsulUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("https://discord.gg/Amet8Yc");
        }
    }
}
