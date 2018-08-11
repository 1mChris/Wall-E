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
    public class Foxholeeminglês
    {
        [Command("Foxeng")]
        [Aliases("foxeng", "FOXENG")]

        public async Task Foxholeinglês(CommandContext ctx)
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
                .WithDescription("**Foxhole**: It is a massive multiplayer game where you will join online with hundreds of players to influence the outcome of a permanent war. This is the ultimate strategy and collaborative tactics game.\n\n**Main Features:** War led by players - Each soldier is a player, the players are the content.\n\n- Sandbox military campaign, where players determine the narrative in a long-term war\n- Players decide all elements of the war, from the manufacture of weapons and building bases to strategy and combat\n- Emerging strategies and tactics make every moment of war unique and extraordinary\n- Your presence remains marked in the world even after you have logged out.\n\n**A living and permanent world** - Join hundreds of players to share a universe divided by war\n\n- Conquer and abandon territories in and around a high-risk conflict\n- Carry out long-term strategies that take days of planning, shifting the tide of war with a minimum number of casualties\n- Join an alternate universe where the great war never ends. And the world has been in conflict for over a century\n- Play as an enduring character throughout the war, gaining notoriety and influence on your faction.\n\n**Realistic Tactics and Combat** - Tense, intelligent battles keep you sweating in anticipation\n\n- Capture and configure logistics routes to keep your front line well equipped\n- Ammunition, resources and information are limited, requiring players to work together to survive\n- Dynamic battle conditions: Use the time of day and terrain features to take advantage of\n- Tactical combat with high point of view, where your skill and strategies are more important than statistics or experience points\n\n**Read more**: https://store.steampowered.com/app/505460/Foxhole/\n\n")
                .AddField(name:"**Secretary**:", value: $"{names}\n\n**IBGE Officer**: <@285539482953056256>, <@95614784350715904>\n\n**Download Link**: https://store.steampowered.com/app/505460/Foxhole/\n*(The game is paid and is in Early Access)*")
                .WithFooter("Command requested by: " + ctx.Member.Username, icon_url: self.AvatarUrl);
            await ctx.RespondAsync(embed: embed);
        }
    }
}