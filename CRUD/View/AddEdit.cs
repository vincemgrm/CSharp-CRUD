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
    public partial class AddEdit : UserControl
    {
        public AddEdit()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Controller.Service.ShowUC(new Load(), this.Parent as Panel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Models.Students.IDNumber = txtIDnumber.Text;
            Models.Students.FullName = txtFullName.Text;
            Models.Students.Save(this.Parent as Panel);

        }

        private void AddEdit_Load(object sender, EventArgs e)
        {
            if (Models.Students.ID > 0)
            {
                txtIDnumber.Text = Models.Students.IDNumber;
                txtFullName.Text = Models.Students.FullName;
            }
        }       
    }
}
