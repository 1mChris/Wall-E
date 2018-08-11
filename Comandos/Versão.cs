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
    public class Versão
    {
        [Command("Versão")]
        [Aliases("versão", "Versao", "versao", "v")]

       public async Task VersãoWall_E(CommandContext ctx)
       {
            var CorEmbed = new Random();
            int r = CorEmbed.Next(0, 255);
            int g = CorEmbed.Next(0, 255);
            int b = CorEmbed.Next(0, 255);

            string rHex = r.ToString("X");
            string gHex = g.ToString("X");
            string bHex = b.ToString("X");
            int cor = Convert.ToInt32(rHex + gHex + bHex, 16);

            DiscordUser self = ctx.Member;
            var embed = new DiscordEmbedBuilder();
            embed.WithColor(new DiscordColor(cor))
                .WithAuthor(name: "v1.3.3")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
       }
    }
}
