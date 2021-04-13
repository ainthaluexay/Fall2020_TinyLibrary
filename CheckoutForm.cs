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
    public partial class CheckoutForm : Form
    {
        List<BookStore> allBooks = new List<BookStore>();
        public CheckoutForm()
        {
            InitializeComponent();
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            BookStore b = allBooks.Find(x => x.Isbn == isbnTextBox.Text);
            if (b != null)
            {
                isbnTextBox.Text = b.Isbn;
                isbnTextBox.ReadOnly = true;
                titleTextBox.Text = b.Title;
                authorTextBox.Text = b.Author;
                totalCopiesTextBox.Text = b.TotalCopies.ToString();
                copiesOnHandTextBox.Text = b.CopiesOnHand.ToString();



            }
            else
            {
                MessageBox.Show("Sorry, there is no book with that ISBN.");
                isbnTextBox.Focus();
                isbnTextBox.SelectAll();
            }
        }
        private void CheckoutForm_Load(object sender, EventArgs e)
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



        private void checkoutButton_Click(object sender, EventArgs e)
        {
            {
                BookStore b = allBooks.Find(x => x.Isbn == isbnTextBox.Text);
                b.CopiesOnHand -= 1;
            }
            MessageBox.Show("You have checked out 1 copy.");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            using (StreamWriter sr = File.CreateText("BookList.txt"))
            {
                foreach (BookStore b in allBooks)
                {

                    sr.WriteLine(isbnTextBox.Text);
                    sr.WriteLine(titleTextBox.Text);
                    sr.WriteLine(authorTextBox.Text);
                    sr.WriteLine(totalCopiesTextBox.Text);
                    sr.WriteLine(b.CopiesOnHand);
                }



            }

            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
