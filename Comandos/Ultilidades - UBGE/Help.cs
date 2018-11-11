using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Help : BaseCommandModule
    {
        [Command("help")]
        [Aliases("ajuda")]

        public async Task HelpWall_E(CommandContext ctx) {
            IEnumerable<Command> Lista = Wall_E.Instance.Discord.GetCommandsNext().RegisteredCommands.Values;
            List<Command> Lista2 = Lista.ToList();
            //var embed = new DiscordEmbedBuilder();
            DiscordColor cor;
            cor = new Utilidades.Utilidades().randomColor();
            DiscordUser self = ctx.Member;

            string Builder = "\n";

            var interact = ctx.Client.GetInteractivity();
            foreach (var comando in Lista2.Distinct()) {
                Builder += $"{comando.Name}\n";
            }

            var paginas = interact.GeneratePagesInEmbeds(Builder);

            await interact.SendPaginatedMessage(ctx.Channel, ctx.User, paginas, TimeSpan.FromMinutes(5), TimeoutBehaviour.DeleteMessage);
        }
    }
}
