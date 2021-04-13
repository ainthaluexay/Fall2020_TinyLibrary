using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Show();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            ReturnForm returnForm = new ReturnForm();
            returnForm.ShowDialog();
        }

        private void lostButton_Click(object sender, EventArgs e)
        {
            LostForm lostForm = new LostForm();
            lostForm.ShowDialog();
        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            CheckoutForm checkoutForm = new CheckoutForm();
            checkoutForm.ShowDialog();
        }

       
    }
}
