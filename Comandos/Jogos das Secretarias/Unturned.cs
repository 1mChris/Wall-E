using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Unturned : BaseCommandModule
    {
        [Command("unturned")]

        public async Task UnturnedUBGE(CommandContext ctx) {
            await ctx.TriggerTypingAsync();

            List<DiscordMember> lista = new List<DiscordMember>();
            IEnumerable<DiscordMember> membros = ctx.Guild.Members.Where(m => m.Roles.Any(r => r.Id == valores.Unturned));
            DiscordRole Unturned = ctx.Guild.GetRole(valores.Unturned);

            String names = null;
            int iterate = 0;

            lista = membros.ToList();
            foreach (DiscordMember e in lista.Distinct()) {
                iterate++;
                if (iterate == 1) { names += e.Mention; }
                else { names += $", {e.Mention}"; }
            }

            DiscordColor cor;
            cor = new Utilidades.Utilidades().randomColor();
            DiscordUser self = ctx.Member;
            var embed = new DiscordEmbedBuilder();

            embed.WithColor(cor)
                .WithDescription($"És um sobrevivente num mundo infestado de zombies, e tens de colaborar com os teus amigos e forjar alianças para te manteres vivo.\n\n**UNTURNED: NÃO TE TORNES NUM DELES!**\nTu és dos poucos que ainda não se tornou num zombie. Manteres-te assim vai ser um desafio.\n\n- Sai a correr aos tiros e atrai a atenção de todos, vivos e mortos.\n-Escolhe uma abordagem mais subtil, esgueirando-te pelas sombras e tirando proveito de distrações.\n- Enfrenta e aprende a lidar contra habilidades especiais de inimigos, desde invisibilidade até rajadas de fogo e ataques elétricos.\n\n**Secretaria**:\n{names}\n\nLeia Mais: https://store.steampowered.com/app/304930/Unturned/?l=portuguese\n*(Unturned é free to play)*")
                .WithImageUrl("https://cdn.discordapp.com/attachments/443159405991821323/468136539407384586/Unturned_Logo.png")
                .WithFooter("Comando Requisitado pelo: " + ctx.Member.Username, iconUrl: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);       
        }
    }
}