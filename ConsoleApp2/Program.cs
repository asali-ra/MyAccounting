using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.DataLayer;
using Accounting.DataLayer.Context;
using Accounting.DataLayer.Repository;
using Accounting.DataLayer.Service;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Accounting_DBEntities db = new Accounting_DBEntities(); 
            //ICustomerRepository customer=new CustomerRepository(db);

            //Customers c1 = new Customers()
            //{
            //    FullName="Asal Razmjoo2",
            //    Mobile="09133378766",
            //    Address="Tehran",
            //    Email="a.razmjoo@bahman.ir",
            //    Image="sss2"
            //};
            //customer.InsertCustomer(c1);
            //customer.Save();

            UnitOfWork db = new UnitOfWork();

            var list= db.CustomerRepository.GetAllCustomers();
            db.Dispose();
        }
    }
}
