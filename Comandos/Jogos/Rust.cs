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
    public class Rust
    {
        [Command("Rust")]
        [Aliases("rust", "RUST")]

        public async Task RustUBGE(CommandContext ctx)
        {
            var leofsjal = DiscordEmoji.FromGuildEmote(ctx.Client, 371061892753391617);
            var msgcarregando = await ctx.RespondAsync($"Carregando... {leofsjal}");

            List<DiscordMember> lista = new List<DiscordMember>();
            await msgcarregando.ModifyAsync($"Carregando... 17% {leofsjal}");
            IEnumerable<DiscordMember> membros = ctx.Guild.Members.Where(m => m.Roles.Any(r => r.Id == valores.Rust));
            DiscordRole Rust = ctx.Guild.GetRole(valores.Rust);
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
                .WithDescription($"**Rust**: O único objetivo em Rust é sobreviver. Para fazer isso, você precisará superar dificuldades como fome, sede e frio. Construa um fogueira. Construa um abrigo. Mate animais para pegar sua carne. Proteja-se dos outros jogadores e mate-os por comida e itens. Crie alianças com outros jogadores e forme uma cidade. Faça o que for preciso para sobreviver.\n\n**Rust V25**: É uma versão mais leve do Rust, com menos coisas, mas tem o mesmo intuito do Rust normal.\n\n**Secretaria**:\n{names}\n\n**IP**: net.connect ubgerust.servegame.com:28015\n\n**Link para Download - Rust**: https://store.steampowered.com/app/252490/Rust/\n**Link para Download - Rust V25**: <http://www.mediafire.com/file/a3ji7iz7bws9eki/Rust_By_NitrouX1_y_Raw+PacoXD.rar>\n*(O Rust é pago, já o Rust V25 não é)*")
                .WithImageUrl("https://cdn.discordapp.com/attachments/443159405991821323/468136599020896286/cropped-Logo_Transparent_1.png")
                .WithFooter("Comando Requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}
