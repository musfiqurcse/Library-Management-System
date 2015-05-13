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

namespace LibraryManagementSystem
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        string bookId, bookName, author, edition, genre;

        private void saveButton_Click(object sender, EventArgs e)
        {
            bookId = bookIDTextBox.Text;
            bookName = bookNameTextBox.Text;
            author = authorTextBox.Text;
            edition = editionTextBox.Text;
            genre = genreTextBox.Text;
            string connectionString = @"SERVER = .\SQLEXPRESS; DATABASE =LibraryManagementSystem; INTEGRATED SECURITY = True"; 
            SqlConnection con = new SqlConnection(connectionString);
            string insertQuertOperation = "INSERT INTO LibraryTable VALUES('" + bookId + "','" + bookName + "','" +
                                          author + "','" + edition + "','" + genre + "')";
            SqlCommand insertQuery = new SqlCommand(insertQuertOperation,con);
            con.Open();
            insertQuery.ExecuteNonQuery();
            con.Close();
            bookNameTextBox.Text =
                bookIDTextBox.Text = authorTextBox.Text = editionTextBox.Text = genreTextBox.Text = null;
            MessageBox.Show("Saved Book Information Succefully");

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            ShowInformation newForm =new ShowInformation();
            this.Hide();
            newForm.Closed += (s, args) => this.Close();
            newForm.Show();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
