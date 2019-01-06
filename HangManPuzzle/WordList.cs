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
using System.Threading;


namespace HangManPuzzle
{
    public partial class WordList : Form
    {
        public static string path;
        public WordList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                textBox1.Text = path;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
