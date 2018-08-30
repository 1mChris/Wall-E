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
    public class Bhaskara
    {
        [Command("Bhaskara")]
        [Aliases("bhaskara", "BHASKARA", "B", "b")]

        public async Task BhaskaraMatemática(CommandContext ctx, double a, double b, double c)
        {
            double delta = (b * b) - (4 * a * c);
            double x1 = Math.Round(((0 - b) + Math.Sqrt(delta)) / (2 * a));
            double x2 = Math.Round(((0 - b) - Math.Sqrt(delta)) / (2 * a));
            DiscordColor cor;
            cor = new Utilidades.CorDiscordEmbed().randomColor();
            DiscordUser self = ctx.Member;
            var embed = new DiscordEmbedBuilder();
            embed
           .WithAuthor("Resultado da Bhaskara:", null, null)
           .AddField("A", a.ToString(), true)
           .AddField("B", b.ToString(), true)
           .AddField("C", c.ToString(), true)
           .AddField("Delta", delta.ToString(), true)
           .AddField("X'", x1.ToString(), true)
           .AddField("X''", x2.ToString(), true)
           .WithColor(cor)
           .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(null, false, embed);
        }
    }
}