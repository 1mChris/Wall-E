using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E
{
    public class Calculadora : BaseCommandModule
    {
        [Command("soma")]
        [Aliases("somar", "+", "som")]

        public async Task CalculadoraWall_ESoma(CommandContext ctx, int numero1, int numero2) {
            int resultado;
            resultado = numero1 + numero2;
            await ctx.RespondAsync($"{ctx.Member.Mention} **|** **Resultado =** `{resultado.ToString()}`");
        }

        [Command("subtracacao")]
        [Aliases("subtrair", "subtração", "-", "sub")]

        public async Task CalculadoraWall_ESubtracao(CommandContext ctx, int numero1, int numero2) {
            int resultado;
            resultado = numero1 - numero2;
            await ctx.RespondAsync($"{ctx.Member.Mention} **|** **Resultado =** `{resultado.ToString()}`");
        }

        [Command("divisao")]
        [Aliases("div", "dividir", "divisão", "/")]

        public async Task CalculadoraWall_EDivisao(CommandContext ctx, int numero1, int numero2) {
            int resultado;
            resultado = numero1 / numero2;
            await ctx.RespondAsync($"{ctx.Member.Mention} **|** **Resultado =** `{resultado.ToString()}`");
        }

        [Command("multiplicar")]
        [Aliases("mul", ".")]

        public async Task CalculadoraWall_EMULTIPLICACAO(CommandContext ctx, int numero1, int numero2) {
            int resultado;
            resultado = numero1 * numero2;
            await ctx.RespondAsync($"{ctx.Member.Mention} **|** **Resultado =** `{resultado.ToString()}`");
        }
    }
}
