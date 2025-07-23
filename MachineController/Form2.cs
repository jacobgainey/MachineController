using MachineController.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineController
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtBoxSend.Text = DatabaseFunctions.GetSetting("MultipleCommandText").Value;
            txtBoxSend.SelectionStart = txtBoxSend.Text.Length; // Place the cursor at the end of the text.
            txtBoxSend.SelectionLength = 0;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DatabaseFunctions.SetSetting("MultipleCommandText", txtBoxSend.Text);
            Close();
        }

        //private async void BtnSend_Click(object sender, EventArgs e)
        //{
        //    string data = txtBoxSend.Text.ToUpper().TrimStart().TrimEnd();
        //}
    }
}
