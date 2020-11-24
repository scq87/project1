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

namespace WindowsFormsApp9
{
    public partial class register : Form
    {
        login form1 = null;

        public register(login obj)
        {
            InitializeComponent();
            form1 = obj;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Заполните все окна", "Error");
                }
                else if (textBox3.Text != textBox4.Text)
                {
                    MessageBox.Show("Пароли не совпадают", "Error");
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter("user.txt", true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(textBox1.Text + "|" + textBox2.Text + "|" + textBox3.Text + "|" + textBox4.Text + "$" + "\n");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                MessageBox.Show("User added successfully");
                this.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
