using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Grupos
    {
        [Command("Grupos")]
        [Aliases("grupos")]

        public async Task GruposUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("**Página:** <https://www.facebook.com/ComunidadeUBGE/>\n**SITE:** https://www.ubge.org/\n**Grupo Facebook:** <https://www.facebook.com/groups/ComunidadeUBGE>\n**Steam:** <http://steamcommunity.com/groups/UBGEsteam>\n**Whatsapp: Grupo geral UBGE:** **https://chat.whatsapp.com/2pvXd1y5vlNEzfur3rxXj7**\n\n**[UBGE] Project Reality:** **<https://chat.whatsapp.com/HulAR729yjNHU683Zv8nZE**>\n**[UBGE] Foxhole:** **<https://chat.whatsapp.com/DCpRhL5Gywh3KzVpY5Zdip>**\n**[UBGE] OpenSpades:** **<https://chat.whatsapp.com/9hqvaj7isCC4aveuk5AZjm>**\n**[UBGE] Unturned:** **<https://chat.whatsapp.com/39tTWeTjCZCLk5z2Mu5tLa>**\n\n<https://www.ubge.org/grupos>");
        }
    }
}
