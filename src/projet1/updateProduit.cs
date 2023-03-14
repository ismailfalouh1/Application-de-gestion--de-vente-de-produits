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
    public partial class updateProduit : Form
    {
        FormProduit fp = new FormProduit();
        SqlConnection conn;
        SqlDataAdapter daProduit;
        SqlDataAdapter daCategorie;
        DataSet ds = new DataSet();
        public updateProduit(FormProduit f)
        {
            this.fp = f;
            InitializeComponent();
    
        }
        public void updateProduit_Load(object sender, EventArgs e)
        {
            conn = connection.GetDBConnection();
            conn.Open();
            daProduit = new SqlDataAdapter("select * from Produit", conn);
            daProduit.Fill(ds, "Produit");
            daCategorie = new SqlDataAdapter("select * from Categorie", conn);
            daCategorie.Fill(ds, "Categorie");
            ds.Tables[0].Constraints.Add("refProduit_PK", ds.Tables["Produit"].Columns[0], true);
            catbox.DataSource = ds.Tables["Categorie"];
            catbox.DisplayMember = "nom_cat";
            catbox.ValueMember = "id_cat";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow row;
            row = ds.Tables["Produit"].Rows.Find(reftxt.Text);
            row.BeginEdit();
            row["libelle"] =libtxt.Text;
            row["prix"] = prixtxt.Text;
            row["qte"] = qtetxt.Text;
            row["id_cat"] = catbox.SelectedValue;
            row.EndEdit();
            SqlCommandBuilder cmb = new SqlCommandBuilder(daProduit);
            daProduit.Update(ds.Tables["Produit"]);
            fp.FormProduit_Load();
            MessageBox.Show("Client est mise à jour", "Update");
        }

       
    }
}
