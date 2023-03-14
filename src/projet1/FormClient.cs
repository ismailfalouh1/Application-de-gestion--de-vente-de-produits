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
    public partial class FormClient : Form
    {
        SqlConnection conn;
        SqlDataAdapter dacat;
        DataSet dt = new DataSet();
        public FormClient()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            conn = connection.GetDBConnection();
            conn.Open();
            dacat = new SqlDataAdapter("select * from client", conn);
            dacat.Fill(dt, "Client");
            dataGridViewCl.DataSource = dt.Tables["Client"];
            dt.Tables["Client"].Constraints.Add("NoClient_PK",
            dt.Tables["Client"].Columns[0], true);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            addClient a = new addClient();                //End
            a.TopLevel = false;
            a.Dock = DockStyle.Fill;
            paneladd.Controls.Add(a);
            a.BringToFront();
            a.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            updateClient a = new updateClient();                //End
            a.TopLevel = false;
            a.Dock = DockStyle.Fill;
            paneladd.Controls.Add(a);
            a.BringToFront();
            a.Show();
        }

        private void dataGridViewCl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            updateClient a = new updateClient();
            int index = dataGridViewCl.CurrentRow.Index;
            //  MessageBox.Show(""+index);
            a.TopLevel = false;
            a.Dock = DockStyle.Fill;
            paneladd.Controls.Add(a);
            a.BringToFront();
            a.Show();
            a.txt0.Text = dt.Tables["Client"].Rows[index]["id_client"].ToString();
            a.txt1.Text = dt.Tables["Client"].Rows[index]["nom"].ToString();
            a.txt2.Text = dt.Tables["Client"].Rows[index]["prenom"].ToString();
            a.txt3.Text = dt.Tables["Client"].Rows[index]["tel"].ToString();
            a.txt4.Text = dt.Tables["Client"].Rows[index]["adress"].ToString();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            int index = dataGridViewCl.CurrentRow.Index;
            if (MessageBox.Show("Vous êtes sûr de vouloir supprimer!!", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dacat = new SqlDataAdapter("select * from Client", conn);
                dacat.Fill(dt, "Client");
                String id_client = dt.Tables["Client"].Rows[index]["id_client"].ToString();
                dt.Tables["Client"].Rows.Find(id_client).Delete();

                SqlCommandBuilder cmb = new SqlCommandBuilder(dacat);

                dacat.Update(dt.Tables["Client"]);
                MessageBox.Show("Categorie supprimé avec succès", "Delete");

            }
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            conn = connection.GetDBConnection();
            conn.Open();
            dacat = new SqlDataAdapter("select * from client", conn);
            dacat.Fill(dt, "Client");
            dataGridViewCl.DataSource = dt.Tables["Client"];
            
        }
    }
}
