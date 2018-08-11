using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wall_E.Comandos;

namespace Wall_E.Bot
{
    public class IgnorarComandos_Só_esses_
    {
        [Command("summon")]
        [Aliases("revoke", "block", "lock", "unlock", "name", "REVOKE", "BLOCK", "LOCK", "UNLOCK", "SUMMON", "Revoke", "Block", "Lock", "Unlock", "Summon", "avatar", "Avatar", "AVATAR")]
        
        public async Task IgnorarComandos(CommandContext ctx)
        {
            var guild = await ctx.Client.GetGuildAsync(460875483442184212);
            var log = guild.GetChannel(valores.IdLogWall_E);

            await log.SendMessageAsync($"O membro `{ctx.Member.DisplayName}` utilizou o comando de outro bot `(Manager#1140)`, porque o meu prefixo é o mesmo do que o dele, entretanto eu ignorei normalmente :smile:");
        }
    }
}
