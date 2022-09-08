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
    public partial class Load : UserControl
    {
        public Load()
        {
            InitializeComponent();
        }

        private void Load_Load(object sender, EventArgs e)
        {
            Models.Students.Load(dgv, txtFind);
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Models.Students.Load(dgv, txtFind);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Models.Students.Add(this.Parent as Panel);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Models.Students.ID = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);
            Models.Students.IDNumber = dgv.CurrentRow.Cells[1].Value.ToString();
            Models.Students.FullName = dgv.CurrentRow.Cells[2].Value.ToString();
            Models.Students.Edit(this.Parent as Panel);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Do you really want to delete this item?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) && (dgv.RowCount > 0))
            {
                Models.Students.ID = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);
                Models.Students.Delete(dgv, txtFind);
            }
        }
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Models.Students.Print(dgv, this.Parent as Panel);
        }
    }
}
