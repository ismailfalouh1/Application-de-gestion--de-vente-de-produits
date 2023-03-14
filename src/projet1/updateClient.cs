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
    public partial class updateClient : Form
    {
        FormCommande fp = new FormCommande();
        SqlConnection conn;
        SqlDataAdapter daProduit;
        SqlDataAdapter daCategorie;
        DataSet ds = new DataSet();
        public updateClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow row;
            row = ds.Tables["Client"].Rows.Find(txt0.Text);
            row.BeginEdit();
            row["nom"] = txt1.Text;
            row["prenom"] = txt2.Text;
            row["tel"] = txt3.Text;
            row["adress"] = txt4.Text;
            row.EndEdit();
            SqlCommandBuilder cmb = new SqlCommandBuilder(daProduit);
            daProduit.Update(ds.Tables["Client"]);

            MessageBox.Show("Client est mise à jour", "Update");
        }

        private void updateClient_Load(object sender, EventArgs e)
        {
            conn = connection.GetDBConnection();
            conn.Open();
            daProduit = new SqlDataAdapter("select * from client", conn);
            daProduit.Fill(ds, "Client");
            ds.Tables[0].Constraints.Add("refProduit_PK", ds.Tables["Client"].Columns[0], true);
        }
    }
}
