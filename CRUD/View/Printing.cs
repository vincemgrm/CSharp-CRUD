using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD.View
{
    public partial class Printing : UserControl
    {
        public Printing(object cr)
        {
            InitializeComponent();
            crv.ReportSource = cr;
            crv.Refresh();
        }

        private void Printing_Load(object sender, EventArgs e)
        {
            crv.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel p = this.Parent as Panel;
            p.Controls.Clear();

            Models.Students.UI(p);
        }
    }
}
