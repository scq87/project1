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
    public partial class login : Form
    {
        string[] tmp = null;
        register reg = null;
        forgot_pass fg_pass = null;
        main main = null;
        string[] lines = null;
        string tmp3 = null;
        string tmp4 = null;

        public login()
        {
            InitializeComponent();
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Заполнить", "Error");
                }
                else
                {
                    lines = System.IO.File.ReadAllLines("user.txt");

                    foreach (string line in lines)
                    {
                        if (line.Contains(textBox1.Text))
                        {
                            tmp = line.Select(c => c.ToString()).ToArray();

                            foreach (string pass in tmp.Reverse<string>())
                            {
                                if (pass.Contains("|"))
                                {
                                    break;
                                }
                                tmp3 += pass;
                            }
                            tmp3 = tmp3.Replace("$", "");
                            tmp4 = Reverse(tmp3);

                            MessageBox.Show(tmp4);
                            if (textBox2.Text != tmp4)
                            {
                                MessageBox.Show("pass !=");  
                                break;
                            }
                            else
                            { 
                                if (main != null)
                                {
                                    main.Close();
                                }
                                main = new main(this);
                                main.ShowDialog();
                                
                                break;
                            }   
                        }
                    }
                    tmp4 = null;
                    tmp3 = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (reg != null)
            {
                reg.Close();
            }
            reg = new register(this);
            reg.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fg_pass != null)
            {
                fg_pass.Close();
            }
            fg_pass = new forgot_pass(this);
            fg_pass.ShowDialog();

            
        }
    }
}
