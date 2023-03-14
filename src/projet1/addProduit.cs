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
    public partial class addProduit : Form
    {
        FormProduit fp=new FormProduit();
        DataSet ds = new DataSet();
        SqlDataAdapter daProduit;
        SqlDataAdapter daCategorie;
        public addProduit(FormProduit f)
        {
            this.fp = f;
            InitializeComponent();
           
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            DataRow row;
            row = ds.Tables["Produit"].NewRow();
            row["ref_prod"] = refbox.Text;
            row["libelle"] = libbox.Text;
            row["prix"] = Int16.Parse(prixbox.Text);
            row["qte"] = Int16.Parse(qtebox.Text);
            row["id_cat"] = catBox.SelectedValue;
            ds.Tables["Produit"].Rows.Add(row);
            SqlCommandBuilder cmb = new SqlCommandBuilder(daProduit);
            daProduit.Update(ds.Tables["Produit"]);
            fp.FormProduit_Load();


            MessageBox.Show("Client enregistré.", this.Text);
        }

        private void addProduit_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connection.GetDBConnection();
            conn.Open();

            daProduit = new SqlDataAdapter("select * from Produit", conn);
            daProduit.Fill(ds, "Produit");
            daCategorie = new SqlDataAdapter("select * from Categorie", conn);
            daCategorie.Fill(ds, "Categorie");
            catBox.DataSource = ds.Tables["Categorie"];
            catBox.DisplayMember = "nom_cat";
            catBox.ValueMember = "id_cat";
        }
    }
}
