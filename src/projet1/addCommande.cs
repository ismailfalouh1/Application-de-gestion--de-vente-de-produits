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
    public partial class addCommande : Form
    {
        FormCommande fp;
        DataSet ds = new DataSet();
        SqlDataAdapter daCommande;
        SqlDataAdapter daCategorie;
        public addCommande()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow row;
            row = ds.Tables["Commande"].NewRow();
            row["num_commande"] = 0;
            row["ref_prod"] = comboBox1.Text;
            row["id_client"] = cBox.Text;
            row["date"] = DateTime.Parse(dateTimePicker1.Text);
            row["etat"] = comboBox2.Text;
            
            ds.Tables["Commande"].Rows.Add(row);
            SqlCommandBuilder cmb = new SqlCommandBuilder(daCommande);
            daCommande.Update(ds.Tables["Commande"]);
            fp = new FormCommande();
            fp.FormCommande_Load2();


            MessageBox.Show("Client enregistré.", this.Text);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void depBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void addCommande_Load(object sender, EventArgs e)
        {

            SqlConnection conn = connection.GetDBConnection();
            conn.Open();
            daCommande = new SqlDataAdapter("select * from Commande", conn);
            daCommande.Fill(ds, "Commande");
     
         
        }
    }
}
