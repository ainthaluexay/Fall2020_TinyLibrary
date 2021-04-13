using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class BookStore
    {
        //fields
        private string isbn;
        private string title;
        private string author;
        private int totalCopies;
        private int copiesOnHand;
        //properties
        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public int TotalCopies
        {
            get { return totalCopies; }
            set { totalCopies = value; }
        }
        public int CopiesOnHand
        {
            get { return copiesOnHand; }
            set { copiesOnHand = value; }
        }
        //constructor
        public BookStore(string isbn, string title, string author, int totalCopies, int copiesOnHand)
        {
            this.isbn = isbn;
            this.title = title;
            this.author = author;
            this.totalCopies = totalCopies;
            this.copiesOnHand = copiesOnHand;
        }
        //method
        public void CheckOut()
        {
            totalCopies -= 1;
           
        }

        public void ReturnBook()
        {
            copiesOnHand += 1;
            
        }
        //ToString()
        public override string ToString()
        {
            string str;
            str = string.Format("{0}\n{1}\n{2}\n{3}\n{4}", isbn, title, author, totalCopies, copiesOnHand);
            return str;
        }
        
          


    }
}
