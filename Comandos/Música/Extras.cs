using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Wall_E.Comandos
{
    public class Extras
    {
        public YoutubeAPI YoutubeApi { get; } = new YoutubeAPI("AIzaSyCFUVnPDH9uL5Z59lcr6MVOgOqA_JfbHP4", 10);

        [Command("Play")]
        [Aliases("play", "PLAY", "P", "p")]

        public async Task Pesquisa(CommandContext ctx, [RemainingText] string pesquisa = null)
        {
            if (string.IsNullOrEmpty(pesquisa))
            {
                await ctx.RespondAsync($"{ctx.Member.Mention} infelizmente sua pesquisa foi inválida. Tente novamente mais tarde.");
                return;
            }
            var resultados = (await YoutubeApi.SearchAsync(pesquisa)).ToArray();
            var mensagem = "";

            for (int i = 0; i <= 9; i++)
            {
                mensagem += $"`{i + 1}.` - {resultados[i].Title} - Enviado por: **{resultados[i].Author}**\n";
            }
            var mensagemlista = await ctx.RespondAsync($"{mensagem}\nPara escolher a música desejada digite: ``/Número``\nExemplo: ``/4``\nPara cancelar digite: ``/cancelar``.\n\nEssa mensagem se auto excluirá em 10 segundos.");
            #region Contagem
            await Task.Delay(1000);
            await mensagemlista.ModifyAsync($"{mensagem}\nPara escolher a música desejada digite: ``/Número``\nExemplo: ``/4``\nPara cancelar digite: ``/cancelar``.\n\nEssa mensagem se auto excluirá em 9 segundos.");
            await Task.Delay(1000);
            await mensagemlista.ModifyAsync($"{mensagem}\nPara escolher a música desejada digite: ``/Número``\nExemplo: ``/4``\nPara cancelar digite: ``/cancelar``.\n\nEssa mensagem se auto excluirá em 8 segundos.");
            await Task.Delay(1000);
            await mensagemlista.ModifyAsync($"{mensagem}\nPara escolher a música desejada digite: ``/Número``\nExemplo: ``/4``\nPara cancelar digite: ``/cancelar``.\n\nEssa mensagem se auto excluirá em 7 segundos.");
            await Task.Delay(1000);
            await mensagemlista.ModifyAsync($"{mensagem}\nPara escolher a música desejada digite: ``/Número``\nExemplo: ``/4``\nPara cancelar digite: ``/cancelar``.\n\nEssa mensagem se auto excluirá em 6 segundos.");
            await Task.Delay(1000);
            await mensagemlista.ModifyAsync($"{mensagem}\nPara escolher a música desejada digite: ``/Número``\nExemplo: ``/4``\nPara cancelar digite: ``/cancelar``.\n\nEssa mensagem se auto excluirá em 5 segundos.");
            await Task.Delay(1000);
            await mensagemlista.ModifyAsync($"{mensagem}\nPara escolher a música desejada digite: ``/Número``\nExemplo: ``/4``\nPara cancelar digite: ``/cancelar``.\n\nEssa mensagem se auto excluirá em 4 segundos.");
            await Task.Delay(1000);
            await mensagemlista.ModifyAsync($"{mensagem}\nPara escolher a música desejada digite: ``/Número``\nExemplo: ``/4``\nPara cancelar digite: ``/cancelar``.\n\nEssa mensagem se auto excluirá em 3 segundos.");
            await Task.Delay(1000);
            await mensagemlista.ModifyAsync($"{mensagem}\nPara escolher a música desejada digite: ``/Número``\nExemplo: ``/4``\nPara cancelar digite: ``/cancelar``.\n\nEssa mensagem se auto excluirá em 2 segundos.");
            await Task.Delay(1000);
            await mensagemlista.ModifyAsync($"{mensagem}\nPara escolher a música desejada digite: ``/Número``\nExemplo: ``/4``\nPara cancelar digite: ``/cancelar``.\n\nEssa mensagem se auto excluirá em 1 segundos.");
            await Task.Delay(1000);
            await mensagemlista.DeleteAsync();
            #endregion
        }           
    }
}