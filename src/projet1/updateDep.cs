using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projet1
{
    public partial class updateDep : Form
    {
        FormCategorie fp = new FormCategorie();
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        public updateDep()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow row;
            row = ds.Tables["Departement"].Rows.Find(txt0.Text);
            row.BeginEdit();
            row["nom_dep"] = txt1.Text;
            row.EndEdit();
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.Update(ds.Tables["Departement"]);
            fp.FormCategorie_Load(sender, e);
            MessageBox.Show("Departement est mise à jour", "Update");

        }

        private void updateDep_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connection.GetDBConnection();
            conn.Open();
            da = new SqlDataAdapter("select * from departement", conn);
            da.Fill(ds, "Departement");
            ds.Tables["Departement"].Constraints.Add("NoClient_PK",
           ds.Tables["Departement"].Columns[0], true);
        }
    }
}
