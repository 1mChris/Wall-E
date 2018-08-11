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
    public class FoxholeJogo
    {
        [Command("Foxhole")]
        [Aliases("foxhole", "FOXHOLE")]

        public async Task FoxholeInfo(CommandContext ctx)
        {
            var leofsjal = DiscordEmoji.FromGuildEmote(ctx.Client, 371061892753391617);
            var msgcarregando = await ctx.RespondAsync($"Carregando... {leofsjal}");

            List<DiscordMember> lista = new List<DiscordMember>();
            await msgcarregando.ModifyAsync($"Carregando... 17% {leofsjal}");
            IEnumerable<DiscordMember> membros = ctx.Guild.Members.Where(m => m.Roles.Any(r => r.Id == valores.Foxhole));
            DiscordRole Foxhole = ctx.Guild.GetRole(valores.Foxhole);
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
                .WithImageUrl("https://cdn.discordapp.com/attachments/452508980896333825/466727233017479179/Foxhole.png")
                .WithDescription("**Foxhole**: É um jogo multiplayer massivo onde você se juntará online a centenas de jogadores para influenciar o resultado de uma guerra permanente. Este é o jogo de estratégia e táticas colaborativas definitivo.\n\n**Características principais:** Guerra conduzida pelos jogadores - Cada soldado é um jogador. Os jogadores SÃO o conteúdo.\n\n- Campanha militar Sandbox, onde os jogadores determinam a narrativa numa guerra de longo prazo\n- Os jogadores decidem todos os elementos da guerra, desde a fabricação de armas e construção de bases até estratégia e combate\n- Estratégias e táticas emergentes tornam cada momento da guerra único e extraordinário\n- Sua presença permanece marcada no mundo, mesmo depois de você ter se desconectado\n\n**Um mundo vivo e permanente** - Junte-se a centenas de jogadores para compartilhar um universo dividido pela guerra\n\n- Conquiste e abandone territórios no vai e volta de um conflito de alto risco\n- Execute estratégias de longo prazo que levam dias de planejamento, mudando a maré da guerra com um número mínimo de baixas\n- Junte-se a um universo alternativo onde as grandes guerras nunca terminaram e o mundo está em conflito há mais de cem anos\n- Jogue como um personagem duradouro ao longo da guerra, ganhando notoriedade e influência em sua facção\n\n**Táticas e Combate realistas** - Batalhas tensas e inteligentes que o mantém suando frio de antecipação\n\n- Capture e configure rotas de mantimento para manter sua linha de frente bem equipada\n- Munição, recursos e informações são limitadas, exigindo que os jogadores trabalhem juntos para sobreviver\n- Condições de batalha dinâmicas: use a hora do dia e as características do terreno para obter vantagens\n- Combate tático com ponto de vista elevado, onde sua habilidade e estratégias são mais importantes do que estatísticas ou pontos de experiência\n\n**Leia mais**: https://store.steampowered.com/app/505460/Foxhole/\n\n")
                .AddField(name: "**Secretaria**:", value: $"{names}\n\n**Link para Download**: https://store.steampowered.com/app/505460/Foxhole/\n*(O jogo é pago e está em Early Acess)*")
                .WithFooter("Comando Requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}
