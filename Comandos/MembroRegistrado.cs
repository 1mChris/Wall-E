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
    public class MembroRegistrado
    {
        [Command("Membro")]
        [Aliases("membro", "Membro_Registrado", "membro_registrado", "Mr", "MR", "mr", "MEMBRO_REGISTRADO")]

        public async Task MembroRegistradoUBGE(CommandContext ctx)
        {
            await ctx.RespondAsync("Membros são integrantes mais **oficiais** da comunidade, podem criar seus próprios links de convite, mudar seu nickname e etc. Para se tornar um membro, é preciso:\n-Ter uma semana de Discord UBGE\n-Ter lido as #regras\n-Responder ao Censo Comunitário (https://goo.gl/forms/3jm8kq2Im94bOXYA2)\n-Depois, peça para um Administrador ou Ajudante te dar o cargo");
        }
    }
}
