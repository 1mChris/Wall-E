using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using System;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Wall_E.Bot;

namespace Wall_E.Comandos.Desenvolvedor
{
    public class Memes : BaseCommandModule
    {
        private string CaminhoMemeModificar = Directory.GetCurrentDirectory() + @"\Léo.png";
        private string Salvar = Directory.GetCurrentDirectory() + @"\Meme.png";

        Graphics G;
        Bitmap Bit;
        Image Meme;

        [Command("memeleo")]
        [Aliases("memesleo", "memesléo")]

        public async Task MemesUBGE(CommandContext ctx, string texto1) {
            await ctx.TriggerTypingAsync();

            try {
                Meme = Image.FromFile(CaminhoMemeModificar);
            }
            catch (Exception ex) {
                await ctx.RespondAsync(ex.ToString());
                Log.Error(ex.ToString());
            }

            Bit = new Bitmap(Meme.Width, Meme.Height);
            G = Graphics.FromImage(Bit);

            G.Clear(Color.Black);
            G.DrawImage(Meme, new Point(0, 0));
            G.DrawString(texto1, new Font("Arial", 25, FontStyle.Bold), Brushes.White, 10, 10);

            G.Dispose();
            Meme.Dispose();

            Bit.Save(Salvar, ImageFormat.Png);
            await ctx.RespondWithFileAsync(Salvar);
        }
    }
}