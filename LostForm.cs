using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project_1
{
    public partial class LostForm : Form
    {
        List<BookStore> allBooks = new List<BookStore>();
        public LostForm()
        {
            InitializeComponent();
        }

        private void LostForm_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("BookList.txt"))
            {
                string isbn;
                while ((isbn = sr.ReadLine()) != null)
                {
                    BookStore b = new BookStore(isbn, sr.ReadLine(), sr.ReadLine(), int.Parse(sr.ReadLine()), int.Parse(sr.ReadLine()));
                    allBooks.Add(b);
                }
            }

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            BookStore b = allBooks.Find(x => x.Isbn == isbnTextBox.Text);
            if (b != null)
            {
                isbnTextBox.Text = b.Isbn;
               // isbnTextBox.ReadOnly = true;
                titleTextBox.Text = b.Title;
                authorTextBox.Text = b.Author;
                copiesTextBox.Text = b.CopiesOnHand.ToString();
                totalCopiesTextBox.Text = b.TotalCopies.ToString();



            }
            else
            {
                MessageBox.Show("Sorry, there is no book with that ISBN.");
                isbnTextBox.Focus();
                isbnTextBox.SelectAll();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            using (StreamWriter sr = File.CreateText("BookList.txt"))
            {
                foreach (BookStore b in allBooks)
                {

                    sr.WriteLine(isbnTextBox.Text);
                    sr.WriteLine(titleTextBox.Text);
                    sr.WriteLine(authorTextBox.Text);
                    sr.WriteLine(copiesTextBox.Text);
                    sr.WriteLine(totalCopiesTextBox.Text);
               
                }



            }

            Close();
        }
    }
}
