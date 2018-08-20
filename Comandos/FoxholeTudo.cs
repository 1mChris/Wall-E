using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    [Group("Fox-Squad")]
    [Aliases("fox-squad", "fox-s", "f-s", "FOX-SQUAD", "FOX-S", "F-S", "Fox-squad")]

    public class FoxholeTudo
    {
        private object dicionariofoxhole;

        [Command("Formigas")]
        [Aliases("formigas", "FOR", "for")]

        public async Task FormigasUBGE(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            List<DiscordMember> lista = new List<DiscordMember>();
            IEnumerable<DiscordMember> membros = ctx.Guild.Members.Where(m => m.Roles.Any(r => r.Id == valores.IdFormigas));
            DiscordRole Formigas = ctx.Guild.GetRole(valores.IdFormigas);
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
            var embed = new DiscordEmbedBuilder();
            DiscordUser self = ctx.Member;
            embed.WithColor(cor)
                .WithAuthor("Esquadrão Formigas (FOR)", null, "https://cdn.discordapp.com/attachments/438402141132947456/468224266861674507/FOR_LOGO_FINAL.png")
                .WithDescription("Oficiais: <@312749162313809922>, <@254777885674438656> e <@207636038858964992>.\n\n- Principal área de atuação: Logística e Engenharia (construção).\n\n- Filosofia: Não exigiremos muita disciplina no canal de voz, nosso trabalho será na retaguarda e fazer isso em silêncio é chato. Porém, quem parar de \"martelar\" (pegar recurso/construir) vai tomar puxão de orelha! kkk.\n\nNossa ordem de prioridades é:\n\n1) Abastecer as tropas da UBGE que estiverem em campo;\n2) Construir torres ao longo da rota de logística e fortificar pontos importantes;\n3) Ajudar a abastecer o front Colonial (não é o nosso foco pois já há clãs especializados em fazer isso).\n\n**FORtificamos a defesa e FORmentamos a vitória!**")
                .AddField(name: "Membros:", value: $"{names}", inline: true)
                .WithThumbnailUrl("https://cdn.discordapp.com/attachments/438402141132947456/468224266861674507/FOR_LOGO_FINAL.png")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }

        [Command("AlphaGroup")]
        [Aliases("alphagroup", "ALPHAGROUP", "AG", "ag")]

        public async Task AlphaGroupUBGE(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            List<DiscordMember> lista = new List<DiscordMember>();
            IEnumerable<DiscordMember> membros = ctx.Guild.Members.Where(m => m.Roles.Any(r => r.Id == valores.IdAlphaGroup));
            DiscordRole AlphaGroup = ctx.Guild.GetRole(valores.IdAlphaGroup);
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
            var embed = new DiscordEmbedBuilder();
            DiscordUser self = ctx.Member;
            embed.WithColor(cor)
                .WithAuthor("Esquadrão Alpha Group (AG)", null, "https://cdn.discordapp.com/attachments/438402141132947456/468257076406386699/alpha_squad_2_backpreto.png")
                .WithDescription("Oficiais: <@247969272670715904>, <@335398031040184320> e <@301118482467258368>.\n\n- Principal área de atuação: Atuamos em todas as áreas, dependendo do momento da guerra e da vontade dos membros.\n\nFilosofia: Nossa meta é nos tornarmos um grupo altamente habilidoso. Buscaremos sempre fazer a melhor partida possível e trazer a vitória para a UBGE. Novatos também são bem-vindos, desde que tenham real vontade de aprender e cooperar, pois faremos partidas sérias.\n\n\"Versatilidade\" será o nosso nome do meio, todos os nossos membros aprenderão a lidar com qualquer situação adversa do campo de batalha. Esse é o esquadrão para aqueles que não aceitam menos do que ser os melhores.\n\n**Somos a Espada e o Escudo dos Coloniais!**\n\n>> **IMPORTANTE**: Sempre jogamos com push-to-talk.")
                .AddField(name: "Membros:", value: $"{names}", inline: true)
                .WithThumbnailUrl("https://cdn.discordapp.com/attachments/438402141132947456/468257076406386699/alpha_squad_2_backpreto.png")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }

        [Command("Tuiti")]
        [Aliases("tuiti", "t")]

        public async Task TuitiUBGE(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            List<DiscordMember> lista = new List<DiscordMember>();
            IEnumerable<DiscordMember> membros = ctx.Guild.Members.Where(m => m.Roles.Any(r => r.Id == valores.IdTuiti));
            DiscordRole Tuiti = ctx.Guild.GetRole(valores.IdTuiti);
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
            var embed = new DiscordEmbedBuilder();
            DiscordUser self = ctx.Member;
            embed.WithColor(cor)
                .WithAuthor("Esquadrão Tuiti (TiT)", null, "https://cdn.discordapp.com/attachments/362625877160493056/468913882212335616/Tuiti.png")
                .WithThumbnailUrl("https://cdn.discordapp.com/attachments/362625877160493056/468913882212335616/Tuiti.png")
                .WithDescription("Oficiais: <@372805650293588000>, <@176058289312890880> e <@251135216817537025>.\n\n- Principal área de atuação: Operações Navais (desenrolar com o que for disponivel: Apc´s , Barcas, Gunboats, patinhos de borracha, o que tiver!).\n\n- Filosofia: Um time descontraído, nada muito rígido, mas na horas de batalha será necessária disciplina.\n\nO Mar é o foco, mas nada nos impede de atuar quando necessário na terra, e sempre lembre mantenha o respeito e claro, o bom humor, o silêncio é chato!\n\nPrioridades:\n1 - Atuar de Suporte para tropas dá UBGE.\n2 - Atuar com Clãs coloniais.\n3 - Coordenar se possível com as operações de larga escala.")
                .AddField(name: "Membros:", value: $"{names}", inline: true)
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }

        [Command("DivisãoTática")]
        [Aliases("divisãotática", "DIVISÃOTÁTICA", "DT", "dt")]

        public async Task DivisãoTáticaUBGE(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            List<DiscordMember> lista = new List<DiscordMember>();
            IEnumerable<DiscordMember> membros = ctx.Guild.Members.Where(m => m.Roles.Any(r => r.Id == valores.IdDivisãoTática));
            DiscordRole DivisãoTática = ctx.Guild.GetRole(valores.IdDivisãoTática);
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
            var embed = new DiscordEmbedBuilder();
            DiscordUser self = ctx.Member;
            embed.WithColor(cor)
                .WithAuthor("Esquadrão Divisão Tática (DT)")
                .WithDescription("Oficiais: <@97144935764983808>, <@269979622513442837> e <@325142293504065538>.\n\n- Principal área de atuação: Operações Especiais e de Inteligência.\n\nEstilo de jogo: Nosso esquadrão será formado por players experientes e muito competentes, iremos trabalhar apenas com missões precisas e bem pensadas. Iremos atuar somente com inteligência e planejamento prévio.\n\n- Filosofia: Disciplina, calma, inteligência e precisão. Todos devem seguir exatamente a call de quem estiver liderando no momento, não importando qual seja a sua opinião sobre a missão. Agir com calma e inteligência sempre para contornar situações difíceis com a melhor abordagem possível. Precisão e objetivo claro na hora de elaborar alguma operação.\n\nTipos de missões: Reconhecimento, Emboscada, Bloqueio, Sabotagem e Demolição Stealth.")
                .AddField(name: "Membros:", value: $"{names}", inline: true)
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}