using Accounting.DataLayer;
using Accounting.DataLayer.Context;
using System;
using System.Windows.Forms;

namespace Accounting
{
    public partial class ContactInfo3 : Form
    {
        public ContactInfo3()
        {
            InitializeComponent();
        }

        private void ContactInfo3_Load(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        public void btnSelectpc_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pcCustomer.ImageLocation = openFile.FileName;
            }
        }

        private void btnAddorEdit_Click(object sender, EventArgs e)
        {

            using (UnitOfWork db = new UnitOfWork())
            {

                Customers cutomer = new Customers()
                {
                    FullName = txtName.Text,
                    Mobile = txtMobile.Text,
                    Email = txtMail.Text,
                    Address = txtAddress.Text,
                    Image = pcCustomer.ImageLocation
                };

                bool result = db.CustomerRepository.InsertCustomer(cutomer);
                if (result)
                {
                    DialogResult = DialogResult.OK;
                    db.save();
                }


            }
        }
    }
}
