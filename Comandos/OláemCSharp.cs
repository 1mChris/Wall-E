using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Comandos
    {
        [Command("olá")]
        [Aliases("OLÁ", "Olá", "alou", "ALOU", "ALO", "alo", "ola", "OLA")]

        public async Task EAE(CommandContext ctx)
        {
            await ctx.RespondAsync("Marilene");
        }
    }
}