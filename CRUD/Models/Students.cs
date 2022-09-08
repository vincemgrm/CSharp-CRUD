using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD.Models
{
    public class Students
    {
        public static int ID { get; set; }
        public static string IDNumber { get; set; }
        public static string FullName { get; set; }

        public static void Clear()
        {
            Students record = new Students();

            PropertyInfo[] properties = typeof(Students).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                property.SetValue(record, default);
            }
        }
        public static void UI(Panel p)
        {
            Controller.Service.ShowUC(new View.Load(), p);
        }
        public static void Load(DataGridView d, TextBox t)
        {

            string searchstring = Controller.Service.EscapeQuote(t.Text);
            var dt = Controller.MySQL.Pull("select * from students where IDNumber like '%" + searchstring + "%' or FullName like '%" + searchstring + "%'") as IDisposable;
            d.DataSource = dt;
            dt.Dispose();

            FixGrid(d);
        }
        public static void FixGrid(DataGridView d)
        {
            d.Columns[0].Visible = false;
            d.Columns[1].HeaderText = "ID Number";
            d.Columns[2].HeaderText = "Full Name";
        }

        public static void Add(Panel p)
        {
            Clear();
            Controller.Service.ShowUC(new View.AddEdit(), p);
        }
        public static void Edit(Panel p)
        {
            Controller.Service.ShowUC(new View.AddEdit(), p);
        }
        public static void Delete(DataGridView d, TextBox t)
        {
            Controller.MySQL.Push("delete from students where ID =" + ID + "");
            Clear();
            Load(d, t);
        }
        public static void Print(DataGridView d, Panel p)
        {
            DataSet ds = new DataSet();
            ds = new Datasets.Students();
            for (int i = 0; i <= d.RowCount - 1; i++)
            {
                ID = Convert.ToInt32(d[0, i].Value);
                IDNumber = d[1, i].Value.ToString();
                FullName = d[2, i].Value.ToString();
                ds.Tables["students_dt"].Rows.Add(ID, IDNumber, FullName);
            }
           
            Report.Students_cr r = new Report.Students_cr();
            r.SetDataSource(ds.Tables["students_dt"]);

            Controller.Service.ShowUC(new View.Printing(r), p);
        }
        public static void Save(Panel p)
        {
            if (ID > 0)
            {
                Controller.MySQL.Push("update students set IDNumber = '" + IDNumber + "',FullName= '" + FullName + "' where ID =" + ID + "");
            }
            else
            {
                Controller.MySQL.Push("insert into students set IDNumber = '" + IDNumber + "',FullName= '" + FullName + "'");
            }
            Clear();
            Controller.Service.ShowUC(new View.Load(), p);
        }
    }
}
