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
    public partial class updateCommande : Form
    {

        FormCommande fp = new FormCommande();
        SqlConnection conn;
        SqlDataAdapter daProduit;
        SqlDataAdapter daCategorie;
        DataSet ds = new DataSet();
        public updateCommande()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            DataRow row;
            row = ds.Tables["Commande"].Rows.Find(textBox1.Text);
            row.BeginEdit();
            row["ref_prod"] = textBox2.Text;
            row["id_client"] = textBox3.Text;
            row["date"] = DateTime.Parse(dateTimePicker1.Text);
            row["etat"] = comboBox2.Text;
            row.EndEdit();
            SqlCommandBuilder cmb = new SqlCommandBuilder(daProduit);
            daProduit.Update(ds.Tables["Commande"]);
          
            MessageBox.Show("Client est mise à jour", "Update");

        }

        private void updateCommande_Load(object sender, EventArgs e)
        {
            conn = connection.GetDBConnection();
            conn.Open();
            daProduit = new SqlDataAdapter("select * from Commande", conn);
            daProduit.Fill(ds, "Commande");
            ds.Tables[0].Constraints.Add("refProduit_PK", ds.Tables["Commande"].Columns[0], true);
           
        }
    }
}
