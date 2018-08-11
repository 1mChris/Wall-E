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
    public class Unturned
    {
        [Command("Unturned")]
        [Aliases("unturned", "UNTURNED")]

        public async Task UnturnedUBGE(CommandContext ctx)
        {
            var leofsjal = DiscordEmoji.FromGuildEmote(ctx.Client, 371061892753391617);
            var msgcarregando = await ctx.RespondAsync($"Carregando... {leofsjal}");

            List<DiscordMember> lista = new List<DiscordMember>();
            await msgcarregando.ModifyAsync($"Carregando... 17% {leofsjal}");
            IEnumerable<DiscordMember> membros = ctx.Guild.Members.Where(m => m.Roles.Any(r => r.Id == valores.Unturned));
            DiscordRole Unturned = ctx.Guild.GetRole(valores.Unturned);
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
                .WithDescription($"És um sobrevivente num mundo infestado de zombies, e tens de colaborar com os teus amigos e forjar alianças para te manteres vivo.\n\n**UNTURNED: NÃO TE TORNES NUM DELES!**\nTu és dos poucos que ainda não se tornou num zombie. Manteres-te assim vai ser um desafio.\n\n- Sai a correr aos tiros e atrai a atenção de todos, vivos e mortos.\n-Escolhe uma abordagem mais subtil, esgueirando-te pelas sombras e tirando proveito de distrações.\n- Enfrenta e aprende a lidar contra habilidades especiais de inimigos, desde invisibilidade até rajadas de fogo e ataques elétricos.\n\n**Secretaria**:\n{names}\n\nLeia Mais: https://store.steampowered.com/app/304930/Unturned/?l=portuguese\n*(Unturned é free to play)*")
                .WithImageUrl("https://cdn.discordapp.com/attachments/443159405991821323/468136539407384586/Unturned_Logo.png")
                .WithFooter("Comando Requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);       
        }
    }
}