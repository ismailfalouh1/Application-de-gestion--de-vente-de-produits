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
    public partial class FormCommande : Form
    {
        SqlConnection conn;
        SqlDataAdapter da;
        SqlDataAdapter da2;
        SqlDataAdapter da3;
        DataSet dt = new DataSet();
        addCommande a = new addCommande();
        public FormCommande()
        {
            InitializeComponent();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            addCommande a = new addCommande();                //End
            a.TopLevel = false;
            a.Dock = DockStyle.Fill;
            paneladd.Controls.Add(a);
            a.BringToFront();
            a.Show();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            updateCommande a = new updateCommande();                //End
            a.TopLevel = false;
            a.Dock = DockStyle.Fill;
            paneladd.Controls.Add(a);
            a.BringToFront();
            a.Show();
        }

        public void FormCommande_Load2()
        {
            conn = connection.GetDBConnection();
            conn.Open();
            //////////////////////////client////////////////////////
            da = new SqlDataAdapter("select * from client", conn);
            da.Fill(dt, "Client");
            dataGridViewClient.DataSource = dt.Tables["Client"];
            //////////////////////////Produit//////////////////
            da2 = new SqlDataAdapter("select * from Produit", conn);
            da2.Fill(dt, "Produit");
            dataGridViewProduit.DataSource = dt.Tables["Produit"];
            
            ///////////////////////////Commande////////////////////
            da3 = new SqlDataAdapter("select * from Commande", conn);
            da3.Fill(dt, "Commande");
            dataGridViewCommande.DataSource = dt.Tables["Commande"];
           
            ////////////////////////////
        
           // dt.Tables["Ligne_Commande"].Constraints.Add("NoCommande_PK",(dt.Tables["Commande"].Columns[0], dt.Tables["Commande"].Columns[0] ) , true);
            //////////////////////////////
           
        }
        private void FormCommande_Load(object sender, EventArgs e)
        {
            conn = connection.GetDBConnection();
            conn.Open();
            //////////////////////////client////////////////////////
            da = new SqlDataAdapter("select * from client", conn);
            da.Fill(dt, "Client");
            dataGridViewClient.DataSource = dt.Tables["Client"];
            dt.Tables["Client"].Constraints.Add("NoClient_PK",
            dt.Tables["Client"].Columns[0], true);
            //////////////////////////Produit//////////////////
            da2 = new SqlDataAdapter("select * from Produit", conn);
            da2.Fill(dt, "Produit");
            dataGridViewProduit.DataSource = dt.Tables["Produit"];
            dt.Tables["Produit"].Constraints.Add("NoProduit_PK",
            dt.Tables["Produit"].Columns[0], true);
            ///////////////////////////Commande////////////////////
            da3 = new SqlDataAdapter("select * from Commande", conn);
            da3.Fill(dt, "Commande");
            dataGridViewCommande.DataSource = dt.Tables["Commande"];
            dt.Tables["Commande"].Constraints.Add("NoCommande_PK",
            dt.Tables["Commande"].Columns[0], true);
            ////////////////////////////
            da3 = new SqlDataAdapter("select * from Ligne_Commande", conn);
            da3.Fill(dt, "Ligne_Commande");
            // dt.Tables["Ligne_Commande"].Constraints.Add("NoCommande_PK",(dt.Tables["Commande"].Columns[0], dt.Tables["Commande"].Columns[0] ) , true);
            //////////////////////////////
            dt.Relations.Add("client_commandes", dt.Tables["Client"].Columns["id_client"],
            dt.Tables["Commande"].Columns["id_client"]);
            dt.Relations.Add("lcommandes_commandes", dt.Tables["Commande"].Columns["num_commande"],
            dt.Tables["Ligne_Commande"].Columns["num_commande"]);
            dt.Relations.Add("lcommandes_p", dt.Tables["Produit"].Columns["ref_prod"],
            dt.Tables["Ligne_Commande"].Columns["ref_prod"]);
        }

        private void dataGridViewClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadChildData(e.RowIndex);
            a.TopLevel = false;
            a.Dock = DockStyle.Fill;
            paneladd.Controls.Add(a);
            a.BringToFront();
            a.Show();
            a.cBox.Text = dt.Tables["Client"].Rows[e.RowIndex]["id_client"].ToString();
        }

        private void dataGridViewProduit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            a.comboBox1.Text = dt.Tables["Produit"].Rows[e.RowIndex]["ref_prod"].ToString();
        }
        private void LoadChildData(int rowindex)
        {
            var parentRow = dt.Tables["Client"].Rows[rowindex];
            var childRows = parentRow.GetChildRows("client_commandes");
            DataTable childTable = dt.Tables["Commande"].Clone();
            foreach (var row in childRows)
            {

                childTable.ImportRow(row);
            }
            dataGridViewCommande.DataSource = childTable;
        }

        private void dataGridViewCommande_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            updateCommande a = new updateCommande();
            int index = dataGridViewCommande.CurrentRow.Index;
            //  MessageBox.Show(""+index);
            a.TopLevel = false;
            a.Dock = DockStyle.Fill;
            paneladd.Controls.Add(a);
            a.BringToFront();
            a.Show();
            a.textBox1.Text = dt.Tables["Commande"].Rows[index]["num_commande"].ToString();
            a.textBox2.Text = dt.Tables["Commande"].Rows[index]["id_client"].ToString();
            a.textBox3.Text = dt.Tables["Commande"].Rows[index]["ref_prod"].ToString();
            a.dateTimePicker1.Text = dt.Tables["Commande"].Rows[index]["date"].ToString();
            a.comboBox2.Text = dt.Tables["Commande"].Rows[index]["etat"].ToString();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            int index = dataGridViewCommande.CurrentRow.Index;
            if (MessageBox.Show("Vous êtes sûr de vouloir supprimer!!", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                da = new SqlDataAdapter("select * from Commande", conn);
                da.Fill(dt, "Commande");
                String num_commande = dt.Tables["Commande"].Rows[index]["num_commande"].ToString();
                dt.Tables["Commande"].Rows.Find(num_commande).Delete();

                SqlCommandBuilder cmb = new SqlCommandBuilder(da);

                da.Update(dt.Tables["Commande"]);
                MessageBox.Show("Commande supprimé avec succès", "Delete");

            }
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            conn = connection.GetDBConnection();
            conn.Open();
            da3 = new SqlDataAdapter("select * from Commande", conn);
            da3.Fill(dt, "Commande");
            dataGridViewCommande.DataSource = dt.Tables["Commande"];
        }
    }
}
