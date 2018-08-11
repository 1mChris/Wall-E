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
    [Group("cantores")]
    [Aliases("c")]

    public class Cantores
    {
        [Command("ZéRamalho")]
        [Aliases("ZÉRAMALHO", "zéramalho", "zr", "ZR")]

        public async Task ZéRamalhoCantor(CommandContext ctx)
        {
            var CorEmbed = new Random();
            int r = CorEmbed.Next(0, 255);
            int g = CorEmbed.Next(0, 255);
            int b = CorEmbed.Next(0, 255);

            string rHex = r.ToString("X");
            string gHex = g.ToString("X");
            string bHex = b.ToString("X");
            int cor = Convert.ToInt32(rHex + gHex + bHex, 16);

            DiscordUser self = ctx.Member;
            var embed = new DiscordEmbedBuilder();
            embed.WithColor(new DiscordColor(cor))
                .WithAuthor("Zé Ramalho:")
                .WithDescription("**José Ramalho Neto** (Brejo do Cruz, 3 de outubro de 1949), mais conhecido como Zé Ramalho, é um cantor, compositor e músico brasileiro. É primo da cantora Elba Ramalho. Em outubro de 2008, a revista Rolling Stone promoveu a Lista dos Cem Maiores Artistas da Música Brasileira, cujo resultado colocou Zé Ramalho na 41ª posição.\n\nJosé Ramalho nasceu em 3 de outubro de 1949 em Brejo do Cruz/PB, filho de Estelita Torres Ramalho, uma professora do ensino fundamental, e Antônio de Pádua Pordeus Ramalho, um seresteiro. Quando tinha dois anos de idade, seu pai se afogou em uma represa do sertão, e passou a ser criado por seu avô. A relação entre os dois seria mais tarde homenageada na canção \"Avôhai\". Após passar a maior parte da sua infância em Campina Grande, sua família se mudou para João Pessoa. Esperava-se que ele se formasse em Medicina.\n\nAssim que a família se estabeleceu em João Pessoa, ele participou de algumas apresentações de Jovem Guarda, sendo influenciado por Renato Barros, Leno e Lílian, Roberto Carlos, Erasmo Carlos, Golden Boys, Beatles, Rolling Stones, Pink Floyd e Bob Dylan.\n\nEm 1974, seu primeiro filho com Ízis, Christian, nasceu.\n\nAntes de compor, ele escrevia versos de cordel.\n\nLeia mais: https://pt.wikipedia.org/wiki/Zé_Ramalho")
                .WithImageUrl("https://cdn.discordapp.com/attachments/452508980896333825/468102239714672640/ze-ramalho-1210x642.jpg")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }

        [Command("TimMaia")]
        [Aliases("timmaia", "TIMMAIA", "TM", "tm")]

        public async Task TimMaiaCantor(CommandContext ctx)
        {
            var CorEmbed = new Random();
            int r = CorEmbed.Next(0, 255);
            int g = CorEmbed.Next(0, 255);
            int b = CorEmbed.Next(0, 255);

            string rHex = r.ToString("X");
            string gHex = g.ToString("X");
            string bHex = b.ToString("X");
            int cor = Convert.ToInt32(rHex + gHex + bHex, 16);

            DiscordUser self = ctx.Member;
            var embed = new DiscordEmbedBuilder();
            embed.WithColor(new DiscordColor(cor))
                .WithAuthor("Tim Maia:")
                .WithDescription("**Sebastião Rodrigues \"Tim\" Maia** (Rio de Janeiro, 28 de setembro de 1942 — Niterói, 15 de março de 1998), foi um cantor, compositor, maestro, produtor musical, instrumentista e empresário brasileiro, responsável pela introdução do estilo soul na música popular brasileira e reconhecido como um dos maiores ícones da música no Brasil. Suas músicas eram marcadas pela rouquidão de sua voz, sempre grave e carregada, conquistando grande vendagem e consagrando muitos sucessos. Nasceu e cresceu na cidade do Rio de Janeiro, onde, durante a juventude, conviveu com Jorge Ben Jor e Erasmo Carlos. Em 1957, fundou o grupo The Sputniks, no qual cantou junto a Roberto Carlos. Em 1959, emigrou para os Estados Unidos, onde teve seus primeiros contatos com o soul, vindo a ser preso e deportado por roubo e porte de drogas. Em 1970, gravou seu primeiro disco, intitulado Tim Maia, que, rapidamente, tornou-se um sucesso com músicas como \"Azul da Cor do Mar\" e \"Primavera\".")              
                .AddField(name:"Continuação (Parte 1):", value:"Nos três anos seguintes, lançou vários discos homônimos, fazendo sucesso com canções como \"Não Quero Dinheiro(Só Quero Amar)\" e \"Gostava Tanto de Você\". De julho de 1974 a 25 de setembro de 1975, aderiu à doutrina filosófico-religiosa conhecida como Cultura Racional, lançando, nesse período, dois discos, com destaque para \"Que Beleza\" e \"O Caminho do Bem\". Desiludiu-se com a doutrina e voltou ao seu estilo de música anterior, lançando sucessos como \"Descobridor dos Sete Mares\" e \"Me Dê Motivo\".")
                .AddField(name:"Continuação (Parte 2):", value: "Muitas de suas músicas foram gravadas sob a editora Seroma e a gravadora Vitória Régia Discos, sendo um dos primeiros artistas independentes do Brasil. Ganhou o apelido de \"síndico do Brasil\" de seu amigo Jorge Ben Jor na música W/Brasil. Na década de 1990, diversos problemas assolaram a vida do cantor: problemas com as Organizações Globo e a saúde precária, devido ao uso constante de drogas ilícitas e ao agravamento de seu grau de obesidade. Sem condições de realizar uma apresentação no Teatro Municipal de Niterói, saiu em uma ambulância e, após duas paradas cardiorrespiratórias, faleceu em 15 de março de 1998. É amplo seu legado à história da música brasileira, e sua obra veio a influenciar diversos artistas, como seu sobrinho Ed Motta e seu filho Léo Maia (também cantores). A revista Rolling Stone Brasil classificou Tim Maia como o maior cantor brasileiro de todos os tempos, e também como o 9º maior artista da música brasileira.")
                .WithImageUrl("https://cdn.discordapp.com/attachments/452508980896333825/468105786959069186/A77AB968B2B13E72585B82F5B8B305A4E6F4_timmaia.jpg")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            var embedmsg = await ctx.RespondAsync(embed: embed);
        }
    }
}