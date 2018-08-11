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
    public class OpenSpades
    {
        [Command("OpenSpades")]
        [Aliases("openspades", "op", "OPENSPADES")]

        public async Task OSUBGE(CommandContext ctx)
        {
            var leofsjal = DiscordEmoji.FromGuildEmote(ctx.Client, 371061892753391617);
            var msgcarregando = await ctx.RespondAsync($"Carregando... {leofsjal}");

            List<DiscordMember> lista = new List<DiscordMember>();
            await msgcarregando.ModifyAsync($"Carregando... 17% {leofsjal}");
            IEnumerable<DiscordMember> membros = ctx.Guild.Members.Where(m => m.Roles.Any(r => r.Id == valores.OpenSpades));
            DiscordRole OpenSpades = ctx.Guild.GetRole(valores.OpenSpades);
            await msgcarregando.ModifyAsync($"Carregando... 49% {leofsjal}");
            String names = null;
            int iterate = 0;
            await msgcarregando.ModifyAsync($"Carregando... 78% {leofsjal}");
            lista = membros.ToList();
            foreach (DiscordMember e in lista.Distinct())
            {
                iterate++;
                if (iterate == 1) { names += e.Mention; }
                else { names += $", {e.Mention}"; }
            }
            await msgcarregando.ModifyAsync($"Carregado 100% {leofsjal}");
            await msgcarregando.DeleteAsync();
            DiscordColor cor;
            cor = new Utilidades.CorDiscordEmbed().randomColor();
            DiscordUser self = ctx.Member;
            var embed = new DiscordEmbedBuilder();
            embed.WithColor(cor)
                .WithDescription($"**OpenSpades**: É um aperfeiçoamento do Ace of Spades 0.75, que é um jogo de tiro em primeira pessoa criado por Ben Aksoy, com terreno completamente destrutível e vários modos de jogo (incluindo o bem conhecido Capture the Flag) criado pela comunidade.\n\nReflita... :thinking: -> Minecraft + Battlefield + Call of Duty = OpenSpades\n\n**Secretaria**:\n{names}\n\n**IP**: Arena: aos://3888437939:32888\n      TOW: aos://3888437939:32887\n\n**Link para Download**: https://www.buildandshoot.com/download/\n*(O site contêm também uma versão mais leve do OpenSpades, essa versão é recomendada para PCs mais fracos, e o OpenSpades é de graça)*")
                .WithImageUrl("https://cdn.discordapp.com/attachments/443159405991821323/468136520453455873/openspades.png")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}
