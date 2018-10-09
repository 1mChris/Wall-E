using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E.Comandos.Desenvolvedor
{
    public class Cargo_por_cargo
    {
        [Command("cpc"), RequireRolesAttribute("Administradores", "Diretores Comunitários", "Ajudantes Comunitários")]

        public async Task CPC(CommandContext ctx)
        {
            List<DiscordMember> Lista = new List<DiscordMember>();
            IEnumerable<DiscordMember> membros = ctx.Guild.Members.Where(m => m.Roles.Any(r => r.Id == valores.OpenSpades_AoS));
            DiscordRole OpenSpadesMDC = ctx.Guild.GetRole(valores.OpenSpades_MembrodoCla);
            DiscordRole OpenSpadesAOS = ctx.Guild.GetRole(valores.OpenSpades_AoS);

            Lista = membros.ToList();
            foreach (DiscordMember dm in Lista.Distinct())
            {
                if (dm.Roles.Contains(OpenSpadesAOS))
                {
                    await dm.GrantRoleAsync(OpenSpadesMDC);
                }
                else
                {
                    await ctx.RespondAsync("Este(s) membro não contêm o cargo que foi requerido.");
                }
            }
        }
    }
}
