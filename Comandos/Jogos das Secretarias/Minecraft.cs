using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Minecraft
    {
        [Command("Minecraft")]
        [Aliases("minecraft", "mine", "Mine", "maine", "Maine", "Minicrefiti", "minicrefiti", "MINECRAFT")]

        public async Task MinecraftUBGE(CommandContext ctx) {
            await ctx.TriggerTypingAsync();

            List<DiscordMember> lista = new List<DiscordMember>();
            IEnumerable<DiscordMember> membros = ctx.Guild.Members.Where(m => m.Roles.Any(r => r.Id == valores.Minecraft));
            DiscordRole Minecraft = ctx.Guild.GetRole(valores.Minecraft);

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
                .WithDescription($"**Minecraft**: é um jogo eletrônico tipo sandbox e independente de mundo aberto que permite a construção usando blocos (cubos) dos quais o mundo é feito. Foi criado por Markus \"Notch\" Persson. O desenvolvimento de Minecraft começou por volta do dia 10 de maio de 2009. A jogabilidade foi baseada nos jogos Dwarf Fortress, Dungeon Keeper e Infiniminer. Foi vencedor do prêmio VGA 2011 de jogos independentes.\n\nMinecraft é um jogo basicamente feito de blocos, tendo as paisagens e a maioria de seus objetos compostos por eles, e permitindo que estes sejam removidos e recolocados em outros lugares para criar construções, empilhando-os. Além da mecânica de mineração e coleta de recursos para construção, há no jogo mistura de sobrevivência, e exploração.\n\nEle se passa em mundos infinitamente gerados de terreno aberto, montanhas geladas, rios pantanosos, vastas pastagens e muito mais, minecraft é repleto de segredos, maravilhas e perigos.\n\n**Secretaria**:\n{names}\n\n**Link para Download**: https://minecraft.net/pt-br/?ref=m\n*(O jogo é pago)*")
                .WithImageUrl("https://cdn.discordapp.com/attachments/443159405991821323/468136615248920586/huebr.png")
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}
