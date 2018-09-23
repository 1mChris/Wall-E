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
    public class Fórum
    {
        [Command("Forum")]
        [Aliases("forum")]

        public async Task FórumUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("https://www.ubge.org/forum/");
        }
    }
}
