using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Música : BaseCommandModule
    {
        [Command("música")]
        [Aliases("musica")]

        public async Task MúsicaBots(CommandContext ctx) {
            await ctx.RespondAsync("Não utilize os bots de música, sem o consentimento de quem está na sala. (Passível de punição)\n\n<@235088799074484224>: Use !play\n\n<@445330394188087306>: Use toca uma musica ai pra nois\n\n<@184405311681986560>: Use ;;play\n\n<@270198738570444801>: Use !!!play\n\n<@189702078958927872>: Use .m p");
        }
    }
}
