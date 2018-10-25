using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wall_E.Comandos.Desenvolvedor
{
    public class Cargo_por_cargo : BaseCommandModule
    {
        [Command("cpc"), RequireRoles(RoleCheckMode.SpecifiedOnly, "Administradores", "Diretores Comunitários", "Ajudantes Comunitários")]

        public async Task CPC(CommandContext ctx, DiscordRole CargoOriginal, DiscordRole CargoTransferir) {
            List<DiscordMember> Lista = new List<DiscordMember>();
            IEnumerable<DiscordMember> membros = ctx.Guild.Members.Where(m => m.Roles.Any(r => r.Id == CargoOriginal.Id));
            DiscordRole CargoTransfere = ctx.Guild.GetRole(CargoTransferir.Id);

            Lista = membros.ToList();
            foreach (DiscordMember dm in Lista.Distinct()) {
                if (dm.Roles.Contains(CargoOriginal)) {
                    await dm.GrantRoleAsync(CargoTransfere);
                }
                else {
                    await ctx.RespondAsync("Este(s) membro não contêm o cargo que foi requerido.");
                }
            }
        }
    }
}
