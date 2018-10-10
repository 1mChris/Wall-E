using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    [Group("dev")]
    [Aliases("Dev", "DEV")]
    public class roleinfo
    {
        [Command("Roleinfo")]
        [Aliases("roleinfo", "ROLEINFO")]

        public async Task ROLEID(CommandContext ctx, DiscordRole role) {
            var user = ctx.Member;
            var embed = new DiscordEmbedBuilder();
            DiscordUser self = ctx.Member;
            DiscordChannel canal = await ctx.Member.CreateDmChannelAsync();
            embed
                .AddField("ID: ", role.Id.ToString(), true)
                .AddField("Criado por Bot: ", role.IsManaged.ToString(), true)
                .WithColor(role.Color)
                .WithAuthor("Dados do cargo: " + role.Name)
                .WithFooter("Comando requisitado pelo: " + ctx.Member.Username, icon_url:self.AvatarUrl);

            if (user.Id == 322745409074102282 || user.Id == 218752828372549633) {
                await canal.SendMessageAsync(embed: embed);
                await ctx.RespondAsync("Mandei no seu PV, dá uma olhada lá :wink:");
            }
            else {
                await ctx.RespondAsync(":oncoming_police_car: Desculpe este comando só está disponivel para os desenvolvedores!");
            }
        }
    }
}