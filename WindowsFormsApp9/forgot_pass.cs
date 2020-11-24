using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class forgot_pass : Form
    {
        string server = "smtp.gmail.com";
        MailMessage messege;
        string[] lines = null;
        string[] tmp = null;
        string tmp2 = null;
        string tmp3 = null;
        string tmp4 = null;
        login login = null;

        public forgot_pass(login obj)
        {
            InitializeComponent();
            login = null;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Заполнить","Error");
                }
                else
                {
                    lines = System.IO.File.ReadAllLines("user.txt");

                    foreach (string line in lines)
                    {
                        if (line.Contains("$"))
                        {
                            if (line.Contains(textBox1.Text))
                            {
                                tmp = line.Select(c => c.ToString()).ToArray();

                                foreach (string mail in tmp)
                                {
                                    if (mail.Contains("|"))
                                    {
                                        break;
                                    }
                                    tmp2 += mail;
                                }
                                
                                foreach (string mail in tmp.Reverse<string>())
                                {
                                        if (mail.Contains("|"))
                                        {
                                            break;
                                        }
                                        tmp3 += mail;
                                }
                                tmp3 = tmp3.Replace("$", "");
                                tmp4 = Reverse(tmp3);

                                MessageBox.Show(tmp2);
                                MessageBox.Show(tmp4);

                                messege = new MailMessage("itstep2810@gmail.com", tmp2, "Востановление пароля", tmp4);
                               
                                SmtpClient client = new SmtpClient(server);
                                client.Port = 587;
                                client.Credentials = new NetworkCredential("itstep2810@gmail.com","ITstep2020");
                                client.EnableSsl = true;
                                client.SendAsync(messege, "test");

                                tmp2 = null;
                                tmp3 = null;
                                tmp4 = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
