using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E
{
    public class Calculadora
    {
        [Command("Soma")]
        [Aliases("soma", "SOMA", "Somar", "somar", "SOMAR", "som", "+")]

        public async Task CalculadoraWall_ESoma(CommandContext ctx, int numero1, int numero2) {
            int resultado;
            resultado = numero1 + numero2;
            await ctx.RespondAsync($"{ctx.Member.Mention} **|** **Resultado =** `{resultado.ToString()}`");
        }

        [Command("Subtracacao")]
        [Aliases("subtracacao", "sub", "SUBTRACAO", "Subtrair", "subtrair", "SUBTRAIR", "Subtração", "SUBTRAÇÃO", "subtração", "-")]

        public async Task CalculadoraWall_ESubtracao(CommandContext ctx, int numero1, int numero2) {
            int resultado;
            resultado = numero1 - numero2;
            await ctx.RespondAsync($"{ctx.Member.Mention} **|** **Resultado =** `{resultado.ToString()}`");
        }

        [Command("Divisao")]
        [Aliases("divisao", "DIVISAO", "Div", "div", "Dividir", "dividir", "Divisão", "divisão", "DIVISÃO", "/")]

        public async Task CalculadoraWall_EDivisao(CommandContext ctx, int numero1, int numero2) {
            int resultado;
            resultado = numero1 / numero2;
            await ctx.RespondAsync($"{ctx.Member.Mention} **|** **Resultado =** `{resultado.ToString()}`");
        }

        [Command("Multiplicar")]
        [Aliases("multiplicar", "MULTIPLICAR", "Mul", "MUL", "mul", ".")]

        public async Task CalculadoraWall_EMULTIPLICACAO(CommandContext ctx, int numero1, int numero2) {
            int resultado;
            resultado = numero1 * numero2;
            await ctx.RespondAsync($"{ctx.Member.Mention} **|** **Resultado =** `{resultado.ToString()}`");
        }
    }
}
