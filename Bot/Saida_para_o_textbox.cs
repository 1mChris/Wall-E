using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Wall_E.Bot
{
    public class SaidaTextBox : TextWriter {
        RichTextBox textBox = null;

        public SaidaTextBox(RichTextBox Saida) {
            textBox = Saida;
        }

        public override void Write(char value) {
            base.Write(value);
            textBox.BeginInvoke(new Action(() => {
                textBox.AppendText(value.ToString()); 
            }));
        }

        public override Encoding Encoding {
            get { return Encoding.UTF8; }
        }
    }
}