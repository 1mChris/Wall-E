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
    public class LifeIsFeudal
    {
        [Command("Lif")]
        [Aliases("lif", "LIF")]

        public async Task LIFUBGE(CommandContext ctx)
        {
            var leofsjal = DiscordEmoji.FromGuildEmote(ctx.Client, 371061892753391617);
            var msgcarregando = await ctx.RespondAsync($"Carregando... {leofsjal}");

            List<DiscordMember> lista = new List<DiscordMember>();
            await msgcarregando.ModifyAsync($"Carregando... 17% {leofsjal}");
            IEnumerable<DiscordMember> membros = ctx.Guild.Members.Where(m => m.Roles.Any(r => r.Id == valores.LIF));
            DiscordRole LifeIsFeudal = ctx.Guild.GetRole(valores.LIF);
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
                .WithDescription($"**Life is Feudal**: O LiF é um enorme mundo de 21x21km, completamente realizado, com clima naturalista, ciclos de dia-noite e mudanças de estação. Várias áreas produzem diferentes quantidades de recursos específicos da região, enquanto o tempo alterna em toda a terra e pode desempenhar um papel vital no crescimento bem sucedido dos cultivos e a disponibilidade de recursos naturais. Cada região pode oferecer vantagens únicas e condições favoráveis para aventureiros valentes.\n\nA variedade de coisas que podemos fazer no jogo é absurdamente grande!! Quase todo o mapa é editável, terrenos podem ser nivelados, verdadeiras vilas e até castelos podem ser construídos, há uma enorme variedade de recursos, especialidades para o seu personagem, etc. No game, tudo é produzido pelos próprios jogadores, somos nós que temos que arregaçar as mangas para trabalhar todos os itens ou criar relações comerciais/diplomáticas para obtê-las.\n\nÉ um jogo Hardcore e realista, **Life is Feudal: MMO** mostra a vida medieval em grande escala, com 10.000 pessoas por mundo de jogo.\n\n**Secretaria**:\n{names}\n\n**Link para download**: https://store.steampowered.com/app/700030/Life_is_Feudal_MMO/\n*(O jogo é pago e está em Early Acess)*")
                .WithImageUrl("https://cdn.discordapp.com/attachments/443159405991821323/468136625709383680/MMO.png")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}
