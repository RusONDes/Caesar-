using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace зашифровка
{
    public partial class Form1 : Form
    {
        char[] str ;
        char[] al = new char[25];
        string ssss;
        int gup = 0;
        int num = 0;
        int offset = 0;
        int j = 0;
        int key = 0;

        public Form1()
        {
            InitializeComponent();
            
        }
        private void list()
        {
           listBox1.Items.Clear();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "что вы хотите рашифровать ";
            openFileDialog1.Filter = "Все фаилы | *.*|Текстовые фаилы | *.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                list();
                key = int.Parse(textBox1.Text);
                string patc = openFileDialog1.FileName;
                string text = File.ReadAllText(patc);
                text = text.ToLower();
                File.WriteAllText(patc, text);
                str = text.ToCharArray();
               
                for (int i = 0; i < str.Length; i++)
                {
                   if (Char.IsWhiteSpace(str[i]))
                    {
                        str[i] = ' ';
                    }
                   else if (str[i] + key > 122)
                    {
                        offset = (key + str[i]) - 122;
                        str[i] = (char)(96 + offset);
                    }
                   else
                    {
                        str[i] = (char)(str[i] + key);
                    }
                }
                ssss = new string(str);
                listBox1.Items.Add(ssss);
            }
            else
            {
                MessageBox.Show("вы закрыли окно ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            key = int.Parse(textBox1.Text);
            list();

            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsWhiteSpace(str[i]))
                {
                    str[i] = ' ';
                }
                else if (str[i] - key < 97)
                {
                    offset = 97 + (key - str[i]) ;
                    str[i] = (char)(123 - offset);
                }
                else
                {
                    str[i] = (char)(str[i] - key);
                }
            }
            ssss = new string(str);
            listBox1.Items.Add(ssss);


        }

    }
}

