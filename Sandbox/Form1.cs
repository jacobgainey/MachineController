using static System.Net.Mime.MediaTypeNames;

namespace Sandbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    UpdateRichTextBoxSafe($"Processing {i} \n");
                }
            });
        }

        private void SendGCodeToMachine(string gcode)
        {
            UpdateRichTextBoxSafe(gcode);
        }

        private void UpdateRichTextBoxSafe(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.BeginInvoke(new Action(() => 
                UpdateRichTextBoxSafe(text)
                ));

                System.Windows.Forms.Application.DoEvents();
                Thread.Sleep(5);
            }
            else
            {
                richTextBox1.AppendText(text);
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
            }
        }
    }
}
