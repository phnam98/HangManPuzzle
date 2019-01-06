using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HangManPuzzle
{
    public partial class Interface : Form
    {
        int i = 0;
        string file;
        string Target;
        char Guess;
        int Times = 0;
        bool check = false;
        int temp = 0;
        public Interface()
        {
            InitializeComponent();
        }

        private void motRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            WordList wl = new WordList();
            if (wl.ShowDialog() == DialogResult.OK)
                file = WordList.path;
            if (file == null)
                return;
            StreamReader sr = new StreamReader(file);
            while (sr.ReadLine() != null)
                i++;
            sr.Dispose();
            sr = new StreamReader(file);
            Random r = new Random();
            for (int k = 0; k < r.Next(1, i); k++)
                Target = sr.ReadLine();
            sr.Dispose();
            MessageBox.Show("C'est un mot qui a " + Target.Length + " lettres. Vous avez 9 chances seulement et 20 seconds à ajouter 1 mot. \n" + "Bonne Chance !!! ");
            Set();
        }

        private void Set()
        {
            label1.Text = "Le Mot Secret: ";
            label2.Text = "";
            pictureBox1.Image = HangManPuzzle.Properties.Resources._0;
            for (int i = 0; i < Target.Length; i++)
                label2.Text = label2.Text.Insert(i, "*");
            label4.Text = "Les Mots Faux: ";
            Times = 0;
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Target == null)
            {
                MessageBox.Show("Choisez un sujet et essayez plus tard !");
            }
            else
            {
                if (textBox1.Text == "")
                    MessageBox.Show("Votre texte est NULL. \n Essayez plus tard !");
                else
                {
                    temp = 0;
                    Guess = textBox1.Text[0];

                   /* if (temp == 20)
                    {
                        Times++;
                    }*/

                    for (i = 0; i < Target.Length; i++)
                    {
                        if (Char.ToUpper(Target[i]) == Char.ToUpper(Guess))
                        {
                            check = true;
                            label2.Text = label2.Text.Remove(i, 1);
                            label2.Text = label2.Text.Insert(i, Guess.ToString());
                        }
                    }
                    if (label2.Text.ToUpper() == Target.ToUpper())
                        Gagner();

                    if (!check)
                    {
                        // if (Char.ToUpper(Target[i]) != Char.ToUpper(Guess))
                        label4.Text = label4.Text + " " + Char.ToUpper(Guess);
                        Times++;
                        Montrer(Times);
                    }
                }
            }
                check = false;
                textBox1.Focus();
                textBox1.SelectAll();
         }

    private void Montrer(int Times)
    {
        switch (Times)
        {
            case 1:
                pictureBox1.Image = HangManPuzzle.Properties.Resources._1;
                break;
            case 2:
                pictureBox1.Image = HangManPuzzle.Properties.Resources._2;
                break;
            case 3:
                pictureBox1.Image = HangManPuzzle.Properties.Resources._3;
                break;
            case 4:
                pictureBox1.Image = HangManPuzzle.Properties.Resources._4;
                break;
            case 5:
                pictureBox1.Image = HangManPuzzle.Properties.Resources._5;
                break;
            case 6:
                pictureBox1.Image = HangManPuzzle.Properties.Resources._6;
                break;
            case 7:
                pictureBox1.Image = HangManPuzzle.Properties.Resources._7;
                break;
            case 8:
                pictureBox1.Image = HangManPuzzle.Properties.Resources._8;
                break;
            case 9:
                pictureBox1.Image = HangManPuzzle.Properties.Resources._9;
                Perdre();
                break;
            }
    }

        private void Gagner()
        {
            timer1.Stop();
            label5.Text = "Fin !!!";
            MessageBox.Show("           Vous gagnez. \n Le mot secret est: " + Target);
            Recommencer();
        }

        private void Perdre()
        {
            timer1.Stop();
            label5.Text = "Fin !!!";
            MessageBox.Show("           Vous perdez. \n Le mot secret est: " + Target);
            Recommencer();
        }

        private void Recommencer()
        {
            /*  textBox1.Text = "";
              Times = 0;
              label1.Text = "Bienvenue à <HangMan>. ";
              label2.Text = "Choisir le sujet et jouer !!!";*/
            label4.Text = "Les mots faux: ";
            temp = 0;
            Times = 0;
            Set();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Recommencer();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            temp++;
            label5.Text = "Temps: " + temp;
            if(temp == 20)
            {
                temp = 0;
                Times++;
                label4.Text = label4.Text + " -";
                Montrer(Times);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 1;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }
    }
}
