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
    public class Arma3
    {
        [Command("Arma")]
        [Aliases("arma")]

        public async Task Arma3UBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("https://units.arma3.com/unit/ubge");
        }
    }
}
