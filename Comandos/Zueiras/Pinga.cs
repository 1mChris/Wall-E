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
    public class Pinga
    {
        [Command("pinga")]
        [Aliases("PINGA", "Cachaça", "cachaça", "51")]

        public async Task CachaçadoLéo(CommandContext ctx)
        {
            await ctx.RespondAsync("<:51:431184475326775296>");
        }
    }
}
