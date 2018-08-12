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
    public class SelfEmbed
    {
        [Command("Embed")]
        [Aliases("embed", "EMBED")]

        public async Task SelfEmbed2018(CommandContext ctx, [RemainingText] string embedpessoa = null)
        {
            var embed = new DiscordEmbedBuilder();
            DiscordUser self = ctx.Member;
            DiscordColor cor;
            cor = new Utilidades.CorDiscordEmbed().randomColor();
            embed.WithColor(cor)
                .WithDescription(embedpessoa)
            await ctx.RespondAsync(embed: embed);
        }
    }
}
