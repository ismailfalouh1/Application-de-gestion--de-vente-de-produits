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
    public partial class addDep : Form
    {
        FormCategorie fp = new FormCategorie();
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        public addDep()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow row;
            row = ds.Tables["Departement"].NewRow();
            row["nom_dep"] = cattext.Text;
            ds.Tables["Departement"].Rows.Add(row);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.Update(ds.Tables["Departement"]);
            fp.FormCategorie_Load(sender, e);


            MessageBox.Show("Departement enregistré.", this.Text);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cattext_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addDep_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connection.GetDBConnection();
            conn.Open();
            da = new SqlDataAdapter("select * from departement", conn);
            da.Fill(ds, "Departement");
        }
    }
}
