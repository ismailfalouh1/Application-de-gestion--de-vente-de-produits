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
    public partial class FormCategorie : Form
    {
        SqlConnection conn;
        SqlDataAdapter dacat;
        DataSet dt = new DataSet();
        public FormCategorie()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
           addCategorie a = new addCategorie();                //End
            a.TopLevel = false;
            a.Dock = DockStyle.Fill;
            paneladd.Controls.Add(a);
            a.BringToFront();
            a.Show();
        }

        private void paneladd_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            updateCategorie a = new updateCategorie();                //End
            a.TopLevel = false;
            a.Dock = DockStyle.Fill;
            paneladd.Controls.Add(a);
            a.BringToFront();
            a.Show();
        }

        public void FormCategorie_Load(object sender, EventArgs e)
        {
            conn = connection.GetDBConnection();
            conn.Open();
            dacat = new SqlDataAdapter("select * from Categorie", conn);
            dacat.Fill(dt, "Categorie");
            dataGridViewCat.DataSource = dt.Tables["Categorie"];
            dt.Tables["Categorie"].Constraints.Add("NoClient_PK",
            dt.Tables["Categorie"].Columns[0], true);
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewCat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            updateCategorie a = new updateCategorie();
            int index = dataGridViewCat.CurrentRow.Index;
            //  MessageBox.Show(""+index);
            a.TopLevel = false;
            a.Dock = DockStyle.Fill;
            paneladd.Controls.Add(a);
            a.BringToFront();
            a.Show();
            a.txtcat.Text = dt.Tables["Categorie"].Rows[index]["nom_cat"].ToString();
           a.textBox1.Text = dt.Tables["Categorie"].Rows[index]["id_cat"].ToString();

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            int index = dataGridViewCat.CurrentRow.Index;
            if (MessageBox.Show("Vous êtes sûr de vouloir supprimer!!", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dacat = new SqlDataAdapter("select * from Categorie", conn);
                dacat.Fill(dt, "Categorie");
                String id_cat = dt.Tables["Categorie"].Rows[index]["id_cat"].ToString();
                dt.Tables["Categorie"].Rows.Find(id_cat).Delete();

                SqlCommandBuilder cmb = new SqlCommandBuilder(dacat);

                dacat.Update(dt.Tables["Categorie"]);
                MessageBox.Show("Categorie supprimé avec succès", "Delete");

            }
    }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            conn = connection.GetDBConnection();
            conn.Open();
            dacat = new SqlDataAdapter("select * from Categorie", conn);
            dacat.Fill(dt, "Categorie");
            dataGridViewCat.DataSource = dt.Tables["Categorie"];
        }
    }
}
