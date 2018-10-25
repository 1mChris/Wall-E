using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Wall_E.Comandos
{
    public class Help : BaseCommandModule
    {
        [Command("help")]
        [Aliases("ajuda")]

        public async Task HelpWall_E(CommandContext ctx) {
            await ctx.RespondAsync($"```CSharp\n\"Meus comandos:\n- Addtag (jogo)\n- Removetag (jogo)\n- Aliados\n- Arma3\n- Boi\n- Soma (n1) (n2)\n- Subtração (n1) (n2)\n- Divisão (n1) (n2)\n- Multiplicação (n1) (n2)\n- Canal\n- Cantores ZR (Zé Ramalho)\n- Cantores TM (Tim Maia)\n- Censo\n- Central\n- Conselho\n- Criador\n- Denúncia\n- Discords\n- Divsul\n- Doar\n- Facebook\n- Formulários\n- Fórum\n- FoxholeAjuda\n- Fox-Entrar (Esquadrão)\n- Fox-Squad (Esquadrão)\n- Grupos\n- Help\n- ID\n- Discord\n- Jogos\n- Link\n- Medalha\n- Membro_Registrado\n- Música\n- n (n1) (n2)\n- OS Guard\n- OS Desban\n- OS BetterSpades\n- Página\n- Angelo\n- Wysel\n- Paulo\n- Thomas\n- Léo\n- Luiz\n- Nicolas\n- LuizW\n- Pinga\n- Pioneiros\n- Embed\n- ServerInfo\n- Wpp\n- Say\n- Fale (Mesmo sentido do anterior)\n- Talk (Mesmo sentido do anterior)\n- Delta (b, a, c)\n- X do Vértice (-b, a)\n- Y do Vértice (Delta, a)\n\nComando requisitado pelo: {ctx.Member.Username}\"```");
        }
    }
}
