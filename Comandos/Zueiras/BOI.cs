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
    public class BOI
    {
        [Command("Boi")]
        [Aliases("boi", "BOI")]

        public async Task YeahBoi(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder();
            DiscordColor cor;
            cor = new Utilidades.Utilidades().randomColor();
            DiscordUser self = ctx.Member;

            embed.WithColor(cor)
                .WithAuthor(null, null, null)
                .WithImageUrl("https://i.ytimg.com/vi/ezShTla3Qts/maxresdefault.jpg")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}
