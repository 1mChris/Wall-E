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
    [Group("OS")]
    [Aliases("os")]

    public class OpenSpadesComandosDiscord
    {
        [Command("Desban")]
        [Aliases("desban", "DESBAN")]

        public async Task DesbanOP(CommandContext ctx)
        {
            await ctx.RespondAsync("Você foi banido dos servidores da UBGE e quer um possível desban? A secretaria fez um formulário para você preencher para possivelmente você ser desbanido.\n(A secretaria só irá dar 1 chance, se você for banido novamente e estiver usando hack, você não terá outra chance.)\n\nLink: https://docs.google.com/forms/d/e/1FAIpQLSe4IMX-pIUHpnm_VZdrUabI6NNz58gLHUomHV5bifMR2ejshQ/viewform");
        }

        [Command("Guard")]
        [Aliases("guard", "GUARD")]

        public async Task GuardOP(CommandContext ctx)
        {
            await ctx.RespondAsync("Você quer se tornar um guarda nos servidores da UBGE? Faça esse formulário e a secretaria irá discutir seu caso.\n\nLink: https://docs.google.com/forms/d/e/1FAIpQLSc4MPkVKPB3LyGad0CLw9OHPH_oPkcKaBF8XjkgjQj_fv4UTQ/viewform");
        }

        [Command("BetterSpades")]
        [Aliases("betterspades", "BS", "bs")]

        public async Task BetterSpadesOS(CommandContext ctx)
        {
            await ctx.RespondAsync("O BetterSpades é um launcher leve como o Ace of Spades, mas é um pouco mais bonito e agradável que o mesmo.\n\nTrailer do BetterSpades: https://youtu.be/0DxoJFF6EPE\n\nDownload do mesmo: https://github.com/xtreme8000/BetterSpades/release\n\n*Versão: 0.1.3*");
        }

        [Command("Votação")]
        [Aliases("votação", "vote", "v", "V")]

        public async Task VotacaoOS(CommandContext ctx, [RemainingText] string texto = null)
        {
            var emojo = DiscordEmoji.FromName(ctx.Client, ":white_check_mark:");
            var emojo2 = DiscordEmoji.FromName(ctx.Client, ":x:");
            DiscordUser self = ctx.Member;
            DiscordColor cor;
            cor = new Utilidades.Utilidades().randomColor();
            var embed = new DiscordEmbedBuilder();
            embed.WithColor(cor)
                .WithAuthor("Votação:", null, "https://cdn.discordapp.com/attachments/443159405991821323/471879195685814273/images.png")
                .WithDescription(texto)
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync($"<@&{valores.OpenSpades}>, votação abaixo :point_down:");
            var msgembed = await ctx.RespondAsync(embed: embed);
            await msgembed.CreateReactionAsync(emojo);
            await msgembed.CreateReactionAsync(emojo2);
        }     
    }
}