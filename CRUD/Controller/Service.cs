using System;
using System.Drawing;
using System.Windows.Forms;

namespace CRUD.Controller
{
    public class Service
    {
        public static void ShowForm(Form x)
        {
            _ = new Form();
            Form frm = x;
            frm.TopMost = true;
            frm.Show();
            //CommonService.ShowForm(new Form1());
        }
      

        public static void ShowUC(UserControl x, Panel y)
        {
            y.Controls.Clear();
            _ = new UserControl();
            UserControl UC = x;
            UC.Dock = DockStyle.Fill;
            y.Controls.Add(UC);
            UC.Focus();
        }
        public static string EscapeQuote(string msdata)
        {
            return msdata.Replace("'", "''");
        }

        public static int ToInt(object x)
        {
            return Convert.ToInt32(x);
        }
        public static object CellData(DataGridView x, int r, int c)
        {
            return x.Rows[r].Cells[c].Value;
        }

        public static void RegexNum(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }
    }
}
