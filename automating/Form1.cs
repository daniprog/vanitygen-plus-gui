using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace automating
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            keyconv("-G", "Keypair");
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openfile("Keypair");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please enter in both TextBoxes an Private Key.");
            }
            else
            {
                keyconv("-c" + textBox1.Text + " " + textBox2.Text, "CompletePrivKey");
                button4.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openfile("CompletePrivKey");
        }

        private void keyconv(string argument, string namespeichern)
        {
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filepath = filepath + @"\" + namespeichern + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + ".txt";
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.Arguments = argument;
            p.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\keyconv.exe";
            p.Start();
            string strOutput = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            StreamWriter stream = new StreamWriter(filepath);
            stream.WriteLine(strOutput);
            stream.Close();
        }

        private void openfile(string nameoeffnen)
        {
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filepath = filepath + @"\" + nameoeffnen + "_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + ".txt";
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.Arguments = filepath;
            p.StartInfo.FileName = "notepad.exe";
            p.Start();
            p.WaitForExit();
        }
    }
}
