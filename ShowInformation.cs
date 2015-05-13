using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibraryManagementSystem
{
    public partial class ShowInformation : Form
    {
        public ShowInformation()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Main newForm = new Main();
            this.Hide();
            newForm.Closed += (s, args) => this.Close();
            newForm.Show();

        }

        private void ShowInformation_Load(object sender, EventArgs e)
        {
            string connectionString = @"SERVER = .\SQLEXPRESS; DATABASE =LibraryManagementSystem; INTEGRATED SECURITY = True";
            SqlConnection con = new SqlConnection(connectionString);
            string searchQuery = "SELECT * FROM LibraryTable";
            SqlCommand cmd= new SqlCommand(searchQuery,con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            libraryInformaitonDataGridView.Rows.Clear();
            if (reader != null)
            {
                while (reader.Read())
                {
                    libraryInformaitonDataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString(),
                        reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                }
            }
            reader.Close();
            con.Close();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();


        }
    }
}
