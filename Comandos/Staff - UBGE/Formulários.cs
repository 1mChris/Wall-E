using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Formulários : BaseCommandModule
    {
        [Command("formularios")]
        [Aliases("formulários")]

        public async Task FomuláriosUBGE(CommandContext ctx) {
            await ctx.RespondAsync("**Censo Comunitário Geral para membros registrados:** https://goo.gl/forms/3jm8kq2Im94bOXYA2\n\n**Aplicação para cargos do Conselho:** https://goo.gl/forms/OeCCPuIXBvj7BBFD2\n\n**Formulário de sugestão para criação de novos núcleos e etc:** https://goo.gl/forms/e5FIC7QMG8a25Wjf1\n\n**Central de Sugestões/Críticas/Denúncias:** https://goo.gl/forms/zssTOBNen8X9wzk12");
        }
    }
}
