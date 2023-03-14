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
    public partial class FormDepartement : Form
    {
        SqlConnection conn;
        SqlDataAdapter dacat;
        DataSet dt = new DataSet();
        public FormDepartement()
        {
            InitializeComponent();
        }

        private void dataGridViewDep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            updateDep a = new updateDep();
            int index = dataGridViewDep.CurrentRow.Index;
            //  MessageBox.Show(""+index);
            a.TopLevel = false;
            a.Dock = DockStyle.Fill;
            paneladd.Controls.Add(a);
            a.BringToFront();
            a.Show();
            a.txt1.Text = dt.Tables["Departement"].Rows[index]["nom_dep"].ToString();
            a.txt0.Text = dt.Tables["Departement"].Rows[index]["id_dep"].ToString();
        }

        private void FormDepartement_Load(object sender, EventArgs e)
        {
            conn = connection.GetDBConnection();
            conn.Open();
            dacat = new SqlDataAdapter("select * from Departement", conn);
            dacat.Fill(dt, "Departement");
            dataGridViewDep.DataSource = dt.Tables["Departement"];
            dt.Tables["Departement"].Constraints.Add("NoClient_PK",
            dt.Tables["Departement"].Columns[0], true);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            int index = dataGridViewDep.CurrentRow.Index;
            if (MessageBox.Show("Vous êtes sûr de vouloir supprimer!!", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dacat = new SqlDataAdapter("select * from Departement", conn);
                dacat.Fill(dt, "Departement");
                String id_dep = dt.Tables["Departement"].Rows[index]["id_dep"].ToString();
                dt.Tables["Departement"].Rows.Find(id_dep).Delete();

                SqlCommandBuilder cmb = new SqlCommandBuilder(dacat);

                dacat.Update(dt.Tables["Departement"]);
                MessageBox.Show("Departement supprimé avec succès", "Delete");

            }
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            addDep a = new addDep();                //End
            a.TopLevel = false;
            a.Dock = DockStyle.Fill;
            paneladd.Controls.Add(a);
            a.BringToFront();
            a.Show();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            conn = connection.GetDBConnection();
            conn.Open();
            dacat = new SqlDataAdapter("select * from Departement", conn);
            dacat.Fill(dt, "Departement");
            dataGridViewDep.DataSource = dt.Tables["Departement"];
        }
    }
}
