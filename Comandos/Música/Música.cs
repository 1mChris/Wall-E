using DSharpPlus.VoiceNext;
using DSharpPlus.VoiceNext.Codec;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Wall_E.Comandos
{
    public class MúsicaWall_E
    {
        [Command("Play")]
        [Aliases("play", "plei")]

        public async Task PLAY(CommandContext ctx, string música)
        {
            var param = "";
            var split = música.Split('=')[1];
            var guild = await ctx.Client.GetGuildAsync(460875483442184212);
            var log = guild.GetChannel(valores.IdLogWall_E);
            string filename = Path.Combine(Directory.GetCurrentDirectory(), "youtube-dl.exe");

            if (Uri.TryCreate(música, UriKind.Absolute, out Uri uri))
            {
                param = música + " --extract-audio --audio-format mp3 --audio-quality 0 --no-check-certificate -o \"" + Directory.GetCurrentDirectory() + "/play/queue/%(id)s.%(ext)s ";

                var proc = Process.Start(filename, param);
                proc.EnableRaisingEvents = true;
                proc.Exited += async (sender, e) =>
                {
                    var vnext = ctx.Client.GetVoiceNextClient();
                    var vnc = vnext.GetConnection(ctx.Guild);
                    var vstat = ctx.Member?.VoiceState;
                    if (vstat?.Channel == null)
                    {
                        await ctx.RespondAsync("Você não está em um canal de voz.");
                        return;
                    }
                    else
                    {
                        if (vnc != null)
                        {
                            await ctx.RespondAsync("Já conectei.");
                            return;
                        }
                        else
                        {
                            vnc = await vnext.ConnectAsync(vstat.Channel);
                            await log.SendMessageAsync($"Me conectei no canal: `{vstat.Channel}` para tocar música.");
                        }
                    }
                    while (vnc.IsPlaying)
                        await vnc.WaitForPlaybackFinishAsync();

                    await ctx.Message.RespondAsync($"Tocando: `{música}`");
                    await vnc.SendSpeakingAsync(true);
                    filename = Directory.GetCurrentDirectory() + "\\play\\queue\\" + split + ".mp3";
                    var psi = new ProcessStartInfo
                    {
                        FileName = "ffmpeg",
                        Arguments = $"-i \"{filename}\" -ac 2 -f s16le -ar 48000 pipe:1",
                        RedirectStandardOutput = true,
                        UseShellExecute = false
                    };
                    var ffmpeg = Process.Start(psi);
                    var ffout = ffmpeg.StandardOutput.BaseStream;

                    var buff = new byte[3840];
                    var br = 0;
                    while ((br = ffout.Read(buff, 0, buff.Length)) > 0)
                    {
                        if (br < buff.Length)
                            for (var i = br; i < buff.Length; i++)
                                buff[i] = 0;

                        await vnc.SendAsync(buff, 20);
                    }
                    await vnc.SendSpeakingAsync(false);
                    vnc.Disconnect();
                };
            }
            else
            {
                await ctx.RespondAsync("Ainda não sei utilizar o google");
            }
        }
    }
}
