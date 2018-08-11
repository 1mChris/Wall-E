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
    public class Ajuda
    {
        [Command("Ajuda")]
        [Aliases("ajuda", "AJUDA")]

        public async Task WallEAjuda(CommandContext ctx)
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
                .WithAuthor("Aqui estão meus comandos :)")
                .WithThumbnailUrl("https://cdn.discordapp.com/attachments/206808743986462720/447799956858994698/avatar.png")
                .AddField(name: "__Para me fazer perguntas__:", value: "Só me mencionar e colocar uma interrogação ao final da frase, eu responderei com: **Sim, Não, Talvez, Com Certeza, Provável, Provavelmente Sim, Provavelmente Não**.", inline: false)
                .AddField(name: "__Jogos__:", value: "Para saber informações dos jogos, só me mencionar e digitar: <@445330394188087306> Foxhole, PR, Lif, Foxeng, Rust, OpenSpades, Minecraft; ou .Foxhole, .PR, .Lif, .Foxeng, .Rust, .OpenSpades, .Minecraft", inline: false)
                .AddField(name: "__Para saber mais da UBGE__:", value: "Digite: <@445330394188087306> UBGE ou .UBGE", inline: false)
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}
