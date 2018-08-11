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
    public class Canal
    {
        [Command("Canal")]
        [Aliases("canal")]

        public async Task CanaldoLéo(CommandContext ctx)
        {
            await ctx.RespondAsync("https://www.youtube.com/user/LeoFreitas021?feature=mhee");
        }
    }
}
