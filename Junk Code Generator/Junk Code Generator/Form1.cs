using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Junk_Code_Generator
{
    public partial class Form1 : Form
    {
        private bool isConsole;
        private bool notEditText = true;

        private string finalCode = "";
        private string randomVarName = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (selected == "Console App")
            {
                isConsole = true;
                checkBox1.Checked = false;
            }

            if (selected == "Non Console App (DLL or external menu)")
            {
                checkBox1.Checked = true;
                isConsole = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) notEditText = false;
            if (!checkBox1.Checked) notEditText = true;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string RandomInteger(int length)
        {
            const string chars = "123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            finalCode = "";
            if (isConsole && !notEditText)
            {
                for (int i = 0; i < 20; i++)
                {
                    finalCode += "printf(\"" + RandomString(8) + "\"); ";
                    if (i == 4 || i == 8 || i == 12 || i == 16 || i == 20) finalCode += "\n";
                }
            }
            if (isConsole && notEditText || !isConsole)
            {
                randomVarName = RandomString(6);
                finalCode += "int " + randomVarName + " = " + RandomInteger(8) + " ";
                for (int i = 0; i < 20; i++)
                {
                    finalCode += "if(" + randomVarName + " = " + RandomInteger(8) + ") ";
                    finalCode += randomVarName + " = " + RandomInteger(8) + "; ";
                    if (i == 4 || i == 8 || i == 12 || i == 16 || i == 20) finalCode += "\n";
                }
            }

            textBox1.Text = finalCode;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
