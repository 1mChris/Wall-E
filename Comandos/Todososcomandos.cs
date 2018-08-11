using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Wall_E.Comandos
{
    public class Todososcomandos
    {
        [Command("Comandos")]
        [Aliases("comandos", "COMANDOS", "help", "HELP")]

        public async Task TodososComandos(CommandContext ctx)
        {
            DiscordColor cor;
            cor = new Utilidades.CorDiscordEmbed().randomColor();
            DiscordUser self = ctx.Member;
            var embed = new DiscordEmbedBuilder();
            embed.WithColor(cor)
                .AddField(name:"Comandos (Parte 1):", value: "Ajuda\nAliados\nAngelo\nArma\nBOI\nOS BetterSpades\nCanal\nCenso\nCentral\nConselho\nCriador\nDenuncia\nDiogo\nDiscords\nDivsul\nDoar\nOS Desban\nFacebook\nFormularios\nForum\nPaulo\nWysel\nc TimMaia\nFox-squad Formigas\nFox-squad Tuiti\nGrupos\nN (Nº à Nº)\nUBGE", inline:true)
                .AddField(name:"Comandos (Parte 2):", value:"Foxholeajuda\nID\nDiscord\nLéo\nLuiz\nLuizw\nLink\nJogos\nMembro\nMúsica\nNicolas\nOlá\nPágina\nPinga\nOS Guard\nPioneiros\nRex\nComandos\nVdev\nVersão\nc ZéRamalho\nFox-squad AlphaGroup\nFox-squad DivisãoTática\nEmbed\nWpp\nAddtag (Jogo)\nThomas", inline:true)
                .AddField(name:"Jogos:", value:"Foxhole\nFoxeng\nLIF\nMinecraft\nOpenSpades\nPR\nRust\nUnturned", inline:true)
                .AddField(name:"__ATENÇÃO!__", value:"Meu prefixo é `/` e todos esses comandos podem ser escritos tanto em maiúsculo e minúsculo.", inline:false)
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url:self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}