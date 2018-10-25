using DSharpPlus.Entities;
using System;
using System.Linq;

namespace Wall_E.Utilidades
{
    public class Utilidades
    {
        public DiscordColor randomColor() {
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

        public int getTime(string tempo) {
            int time = 0;
            if (tempo.Contains('s')) {
                Int32.TryParse(tempo.Split('s')[0], out time);
                time = time * 1000;
            }
            else if (tempo.Contains('m')) {
                Int32.TryParse(tempo.Split('m')[0], out time);
                time = (time * 60) * 1000;
            }
            else if (tempo.Contains('h')) {
                Int32.TryParse(tempo.Split('h')[0], out time);
                time = (time * 3600) * 1000;
            }
            return time;
        }

        public void Wait(int ms)
        {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < ms) {

            }
        }
    }
}