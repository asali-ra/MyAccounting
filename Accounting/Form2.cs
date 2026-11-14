using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using Accounting.DataLayer;
using Accounting.DataLayer.Repository;
using Accounting.DataLayer.Service;
using Accounting.DataLayer.Context;


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

        private void dgCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        public void BindGrid()
        {
            UnitOfWork db = new UnitOfWork();   
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {

                if (dgCustomer.CurrentRow.Cells[0].Value.ToString() != null)
                {
                    int id = Convert.ToInt32(dgCustomer.CurrentRow.Cells[0].ToString());
                    db.CustomerRepository.DeleteCustomer(id);
                }
                else
                {
                    MessageBox.Show("لطفا یک کاربر را انتخاب کنید");
                }
            }
        }
    }
}
