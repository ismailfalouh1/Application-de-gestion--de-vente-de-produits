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
    public partial class addCategorie : Form
    {

        FormCategorie fp = new FormCategorie();
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        SqlDataAdapter da1;
        public addCategorie()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataRow row;
            row = ds.Tables["Categorie"].NewRow();
            row["nom_cat"] = cattext.Text;
            row["id_dep"] = depBox.SelectedValue;
            ds.Tables["Categorie"].Rows.Add(row);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.Update(ds.Tables["Categorie"]);
            fp.FormCategorie_Load(sender, e);


            MessageBox.Show("Client enregistré.", this.Text);
        }

        private void addCategorie_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connection.GetDBConnection();
            conn.Open();
            da = new SqlDataAdapter("select * from Categorie", conn);
            da.Fill(ds, "Categorie");
            da1 = new SqlDataAdapter("select * from departement", conn);
            da1.Fill(ds, "departement");
            //dadep = new SqlDataAdapter("select * from dep", conn);
            //dadep.Fill(ds, "Categorie");
            depBox.DataSource = ds.Tables["departement"];
            depBox.DisplayMember = "nom_dep";
            depBox.ValueMember = "id_dep";
        }

        private void cattext_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void depBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
