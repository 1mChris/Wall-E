using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class WhatsApp
    {
        [Command("WPP")]
        [Aliases("wpp", "WhatsApp", "whatsapp", "Whatsapp", "Wpp")]

        public async Task WhatsAppUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("**Grupo geral UBGE: https://chat.whatsapp.com/2pvXd1y5vlNEzfur3rxXj7**\n\n**[UBGE] Project Reality: <https://chat.whatsapp.com/HulAR729yjNHU683Zv8nZE>**\n**[UBGE] Foxhole: <https://chat.whatsapp.com/DCpRhL5Gywh3KzVpY5Zdip>**\n**[UBGE] OpenSpades: <https://chat.whatsapp.com/9hqvaj7isCC4aveuk5AZjm>**\n**[UBGE] Unturned: <https://chat.whatsapp.com/39tTWeTjCZCLk5z2Mu5tLa>**");
        }
    }
}
