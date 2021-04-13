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
    public partial class AddForm : Form
    {
        List<BookStore> allBooks = new List<BookStore>();
        public AddForm()
        {
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
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

        private void addButton_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(isbnTextBox.Text) || (string.IsNullOrEmpty(titleTextBox.Text) || (string.IsNullOrEmpty(authorTextBox.Text)
               || (string.IsNullOrEmpty(totalCopiesTextBox.Text) || (string.IsNullOrEmpty(copiesOnHandTextBox.Text)))))))
            {
                MessageBox.Show("All fields must be filled.");
            }
            else
            {
                BookStore b = new BookStore(isbnTextBox.Text, titleTextBox.Text, authorTextBox.Text, int.Parse(totalCopiesTextBox.Text), int.Parse(totalCopiesTextBox.Text));
                allBooks.Add(b);
                MessageBox.Show("Book Added");
            }
            isbnTextBox.Clear();
            titleTextBox.Clear();
            authorTextBox.Clear();
            totalCopiesTextBox.Clear();
            copiesOnHandTextBox.Clear();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            using (StreamWriter sr = File.CreateText("BookList.txt"))
            {
                foreach (BookStore b in allBooks)
                {
                    sr.WriteLine(b);
                }
                MessageBox.Show("Inventory updated.");
            }
            Close();
        }
    }
}
