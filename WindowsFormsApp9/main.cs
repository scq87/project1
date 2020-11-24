using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class main : Form
    {
        login login = null;
        
        public main(login obj)
        {
            InitializeComponent();
            login = null;
        }

        private void main_Load(object sender, EventArgs e)
        {
        }
    }
}
