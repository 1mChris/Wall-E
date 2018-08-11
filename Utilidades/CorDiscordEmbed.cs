using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E.Utilidades
{
    public class CorDiscordEmbed
    {
        public DiscordColor randomColor()
        {
            Random _r = new Random(DateTime.Now.Ticks.GetHashCode());
            int r = _r.Next(0, 255);
            int g = _r.Next(0, 255);
            int b = _r.Next(0, 255);
            string rHex = r.ToString("X");
            string gHex = g.ToString("X");
            string bHex = b.ToString("X");
            int cor = Convert.ToInt32(rHex + gHex + bHex, 16);

            DiscordColor color = new DiscordColor(cor);
            return color;
        }
    }
}