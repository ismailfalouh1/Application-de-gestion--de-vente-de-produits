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
    public partial class addClient : Form
    {
        FormProduit fp = new FormProduit();
        DataSet ds = new DataSet();
        SqlDataAdapter daProduit;
        SqlDataAdapter daCategorie;
        public addClient()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addClient_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connection.GetDBConnection();
            conn.Open();

            daProduit = new SqlDataAdapter("select * from client", conn);
            daProduit.Fill(ds, "Client");
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow row;
            row = ds.Tables["Client"].NewRow();
            row["nom"] = txt1.Text;
            row["prenom"] = txt2.Text;
            row["adress"] = txt4.Text;
            row["tel"] = txt3.Text;
            
            ds.Tables["Client"].Rows.Add(row);
            SqlCommandBuilder cmb = new SqlCommandBuilder(daProduit);
            daProduit.Update(ds.Tables["Client"]);
            fp.FormProduit_Load();


            MessageBox.Show("Client enregistré.", this.Text);
        }
    }
}
