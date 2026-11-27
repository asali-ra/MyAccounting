using Accounting.DataLayer;
using Accounting.DataLayer.Context;
using System;
using System.Windows.Forms;
using System.IO;

namespace Accounting
{
    public partial class ContactInfo3 : Form
    {
        public int customerId = 0;
        public ContactInfo3()
        {
            InitializeComponent();
        }

        private void ContactInfo3_Load(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                if (customerId != 0)
                {
                    this.Text = "ویرایش فرم";
                    btnAddorEdit.Text = "ویرایش";
                    var customer = db.CustomerRepository.GetCustomerById(customerId);
                    txtName.Text = customer.FullName;
                    txtMobile.Text = customer.Mobile;
                    txtAddress.Text = customer.Address;
                    txtMail.Text = customer.Email;
                    pcCustomer.ImageLocation = Application.StartupPath + "/Images/" + customer.Image;
                }
            }
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
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(pcCustomer.ImageLocation);
                string path = Application.StartupPath + "/Images";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                Customers customer = new Customers()
                {
                    FullName = txtName.Text,
                    Mobile = txtMobile.Text,
                    Email = txtMail.Text,
                    Address = txtAddress.Text,
                    Image = pcCustomer.ImageLocation
                };

                if (customerId == 0)
                {
                    bool result = db.CustomerRepository.InsertCustomer(customer);

                }
                else
                {
                    customer.CustomerID = customerId;
                    db.CustomerRepository.UpdateCustomer(customer);
                }
                DialogResult = DialogResult.OK;
                db.save();
            }


        }
    }
}
