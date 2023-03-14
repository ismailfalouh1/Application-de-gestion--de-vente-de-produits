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
    public partial class updateCategorie : Form
    {

        FormCategorie fp = new FormCategorie();
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        SqlDataAdapter da1;
        public updateCategorie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow row;
            row = ds.Tables["Categorie"].Rows.Find(textBox1.Text);
            row.BeginEdit();
            row["nom_cat"] = txtcat.Text;
            row["id_dep"] = int.Parse(catbox.SelectedValue.ToString());
            row.EndEdit();
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.Update(ds.Tables["Categorie"]);
            fp.FormCategorie_Load(sender,e);
            MessageBox.Show("Categorie est mise à jour", "Update");
        }

        private void updateCategorie_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connection.GetDBConnection();
            conn.Open();
            da = new SqlDataAdapter("select * from Categorie", conn);
            da.Fill(ds, "Categorie");
            da1 = new SqlDataAdapter("select * from departement", conn);
            da1.Fill(ds, "departement");
            //dadep = new SqlDataAdapter("select * from dep", conn);
            //dadep.Fill(ds, "Categorie");
            ds.Tables["Categorie"].Constraints.Add("NoClient_PK",
           ds.Tables["Categorie"].Columns[0], true);
            catbox.DataSource = ds.Tables["departement"];
            catbox.DisplayMember = "nom_dep";
            catbox.ValueMember = "id_dep";
        }
    }
}
