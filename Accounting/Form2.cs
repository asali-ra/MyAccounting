using Accounting.DataLayer.Context;
using System;
using System.Windows.Forms;


namespace Accounting
{
    public partial class frmAddOrEdit : Form
    {
        public frmAddOrEdit()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }
        public void BindGrid()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dgCustomer.DataSource = db.CustomerRepository.GetAllCustomers();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                string name = dgCustomer.CurrentRow.Cells[1].Value.ToString();



                if (MessageBox.Show($"آیا برای حذف {name}مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgCustomer.CurrentRow.Cells[0].Value.ToString());
                    if (id != 0)
                    {

                        bool response = db.CustomerRepository.DeleteCustomer(id);
                        if (response)
                        {
                            db.save();
                            BindGrid();
                            MessageBox.Show($"حذف {name} با موفقیت انجام شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("حذف موفقیت آمیز نبود");

                        }
                    }
                    else
                    {
                        MessageBox.Show("لطفا یک کاربر را انتخاب کنید");
                    }

                }
                else if (DialogResult == DialogResult.No)
                {
                    MessageBox.Show(" روی نو زدی");

                }
                else
                {
                    MessageBox.Show("نشد");
                }

            }
        }

        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ContactInfo3 contactInfo = new ContactInfo3();
            contactInfo.ShowDialog();
            if (contactInfo.ShowDialog() == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
            txtSearch.Text = "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dgCustomer.DataSource = db.CustomerRepository.GetCustomerByFilter(txtSearch.Text);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgCustomer.CurrentRow != null)
            {
                int CustomerId = int.Parse(dgCustomer.CurrentRow.Cells[0].Value.ToString());
                ContactInfo3 contractInfo = new ContactInfo3();
                contractInfo.customerId = CustomerId;

                if (contractInfo.ShowDialog == DialogResult.Ok)
                {
                    BindGrid();
                }
            }

        }
    }
}