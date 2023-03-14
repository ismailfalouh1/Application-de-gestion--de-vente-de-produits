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
    public partial class FormProduit : Form
    {
        SqlConnection conn;
        SqlDataAdapter da;
        DataSet dt = new DataSet();


        public FormProduit()
        {
            InitializeComponent();
        }
     

        private void iconButton1_Click(object sender, EventArgs e)
        {
            addProduit a = new addProduit(this);                //End
                a.TopLevel = false;
                a.Dock = DockStyle.Fill;
                paneladd.Controls.Add(a);
                
                a.BringToFront();
                a.Show();
               
            
        }
        
        private void iconButton2_Click(object sender, EventArgs e)
        {
            updateProduit a = new updateProduit(this);                //End
            a.TopLevel = false;
            a.Dock = DockStyle.Fill;
            paneladd.Controls.Add(a);
            a.BringToFront();
            a.Show();

        }

        public void FormProduit_Load(object sender, EventArgs e)
        {
            conn = connection.GetDBConnection();
            conn.Open();
            da = new SqlDataAdapter("select * from Produit", conn);
            da.Fill(dt, "Produit");
            dataGridViewProduit.DataSource = dt.Tables["Produit"];
            dt.Tables["Produit"].Constraints.Add("NoClient_PK",
            dt.Tables["Produit"].Columns[0], true);
        }
        public void FormProduit_Load()
        {
            conn = connection.GetDBConnection();
            conn.Open();
            da = new SqlDataAdapter("select * from Produit", conn);
            
            da.Fill(dt, "Produit");
            dataGridViewProduit.DataSource = dt.Tables["Produit"];
            
        }

        private void dataGridViewProduit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            updateProduit a = new updateProduit(this);
            int index = dataGridViewProduit.CurrentRow.Index;
            //  MessageBox.Show(""+index);
            a.TopLevel = false;
            a.Dock = DockStyle.Fill;
            paneladd.Controls.Add(a);
            a.BringToFront();
            a.Show();
            a.reftxt.Text = dt.Tables["Produit"].Rows[index]["ref_prod"].ToString();
            a.libtxt.Text = dt.Tables["Produit"].Rows[index]["libelle"].ToString();
            a.prixtxt.Text = dt.Tables["Produit"].Rows[index]["prix"].ToString();
            a.qtetxt.Text =  dt.Tables["Produit"].Rows[index]["qte"].ToString();
            
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
             int index = dataGridViewProduit.CurrentRow.Index;
            if (MessageBox.Show("Vous êtes sûr de vouloir supprimer!!","Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                da = new SqlDataAdapter("select * from Produit", conn);
                da.Fill(dt, "Produit");
                String ref_prod = dt.Tables["Produit"].Rows[index]["ref_prod"].ToString();
                dt.Tables["Produit"].Rows.Find(ref_prod).Delete();

                SqlCommandBuilder cmb = new SqlCommandBuilder(da);

                da.Update(dt.Tables["Produit"]);
                MessageBox.Show("Client supprimé avec succès","Delete");

            }

        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn = connection.GetDBConnection();
            conn.Open();
            dataGridViewProduit.DataSource = dt.Tables["Produit"];
            
        }
    }
}
