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
    public class PRNG
    {
        [Command("Número")]
        [Aliases("número", "n")]
        public async Task NúmeroAleatório(CommandContext ctx, int min, int max)
        {
            DiscordColor cor;
            cor = new Utilidades.Utilidades().randomColor();
            DiscordUser self = ctx.Member;
            var número = new Random(DateTime.Now.Ticks.GetHashCode());
            var num = número.Next(min, max);
            var embed = new DiscordEmbedBuilder();
            embed.WithColor(cor)
                .WithDescription("Número: " + num)
                .WithImageUrl("https://www.otvfoco.com.br/wp-content/uploads/2018/01/silvio-risonho.jpg")
                .WithAuthor("Peão do Baú Simulator", null, "https://logodownload.org/wp-content/uploads/2013/12/sbt-logo-1-1.png")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}