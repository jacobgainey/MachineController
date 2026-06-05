using MachineController.Functions;
using MachineController.Objects;

namespace MachineController
{
    public partial class Form2 : Form
    {
        private Macro macro;

        public Form2(Macro m_macro)
        {
            InitializeComponent();
            macro = m_macro;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = macro.Name;
            textBox2.Text = macro.Gcode;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DatabaseFunctions.SetMacroGcode(macro.Id, textBox1.Text, textBox2.Text);
            Close();
        }
    }
}