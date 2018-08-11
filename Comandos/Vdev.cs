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
    public class Vdev
    {
        [Command("Versãodev")]
        [Aliases("vdev", "vDev", "VDev")]

        public async Task VDevWall_E(CommandContext ctx)
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
                .WithThumbnailUrl("https://cdn.discordapp.com/attachments/452508980896333825/466050287837380616/68747470733a2f2f646576656c6f7065722e6665646f726170726f6a6563742e6f72672f7374617469632f6c6f676f2f6373.png")
                .AddField(name: "__Sobre__:", value: "Quem me criou foi o <@322745409074102282> com a ajuda do <@155774074885242880>, a minha 1ª linguagem foi python, agora estou usando C# e estou atualmente na versão 1.3.3", inline: false)
                .AddField(name: "__C#__:", value: "C# é uma linguagem de programação, multiparadigma, de tipagem forte, desenvolvida pela Microsoft como parte da plataforma .NET.", inline: false)
                .AddField(name: "__Documentação DSharpPlus:__", value: "https://dsharpplus.emzi0767.com", inline: false)
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}
