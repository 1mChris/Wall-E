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
    public class ProjectReality
    {
        [Command("PR")]
        [Aliases("pr")]

        public async Task PRUBGE(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            List<DiscordMember> lista = new List<DiscordMember>();
            IEnumerable<DiscordMember> membros = ctx.Guild.Members.Where(m => m.Roles.Any(r => r.Id == valores.ProjectReality));
            DiscordRole ProjectReality = ctx.Guild.GetRole(valores.ProjectReality);
            String names = null;
            int iterate = 0;
            lista = membros.ToList();
            foreach (DiscordMember e in lista.Distinct())
            {
                iterate++;
                if (iterate == 1) { names += e.Mention; }
                else { names += $", {e.Mention}"; }
            }
            DiscordColor cor;
            cor = new Utilidades.CorDiscordEmbed().randomColor();
            DiscordUser self = ctx.Member;
            var embed = new DiscordEmbedBuilder();
            embed.WithColor(cor)
                .WithDescription($"**Project Reality**: Project Reality, é um simulador de guerras, onde suas partidas são organizadas em esquadrões, onde cada squad possui uma função diferente. Por exemplo squad focado em infantaria, outro de só apc, outro de tank, outro de Helicópteros pesados e jatos, outro só de logística. Perante isso cada squad e cada pessoa depende da outra pois dentro de um esquadrão cada pessoa tem a sua função diferente (tirando os médicos que pelo menos tem 2 por squad).\n\nPor exemplo um líder do esquadrão, que organiza o squad e comunica-se com os outros; o AR (suporte), cujo possui normalmente metralhadoras de longo alcanço para ajudar o esquadrão avançar; o Médico, sem ele o grupo não consegue chegar até o fim. Tendo cada kit sua especialidade e necessidade.\n\nNisso o game acaba virando um jogo de estratégias e soluções para avançar no campo de batalha. Onde cada um depende do outro para prosseguir.\n\nNem todos jogos de fps que você jogou salvarão você em uma partida de PR, o jogo simplesmente único e fantástico, sendo um dos melhores simulador que já criaram. Nós da comunidade Ubge, possuímos um servidor de treino para nossos membros.\n\nSe você não se contenta com o velho e repetitivo estilo do “tiro, porrada e bomba” e procura um jogo que tenha um “algo a mais”, então há uma vaga te esperando em nosso esquadrão!\n\n**Secretaria**:\n{names}\n\n**IP**: 189.19.219.125\n**Porta**: 16567\n\n**Link para download**: https://www.realitymod.com/downloads")
                .WithImageUrl("https://cdn.discordapp.com/attachments/443159405991821323/468136534810558474/Project_Reality_Dogtags_Logo_256.png")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}
