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
    public class Página
    {
        [Command("Página")]
        [Aliases("página", "Pagina", "pagina")]

        public async Task PáginaUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("**Página:** https://www.facebook.com/ComunidadeUBGE/\n**SITE:** https://www.ubge.org/\n**Grupo Facebook:** https://www.facebook.com/groups/ComunidadeUBGE\n**Steam:** http://steamcommunity.com/groups/UBGEsteam\n\nhttps://www.ubge.org/grupos");
        }
    }
}
