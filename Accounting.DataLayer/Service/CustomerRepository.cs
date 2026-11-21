using Accounting.DataLayer.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using EntityState = System.Data.Entity.EntityState;


namespace Accounting.DataLayer.Service
{

    public class CustomerRepository : ICustomerRepository
    {


        private Accounting_DBEntities db;
        public CustomerRepository (Accounting_DBEntities context)
        {
            db = context;
        }
        public List<Customers> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public Customers GetCustomerById(int customerID)
        {
            return db.Customers.Find(customerID);
        }

        public bool InsertCustomer(Customers customer)
        {
            try
            {
                db.Customers.Add(customer);
                return true;

            }
            catch { return false; }
        }

        public bool UpdateCustomer(Customers customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Modified;
                return true;
            }
            catch { return false; }
        }
        public bool DeleteCustomer(Customers customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Deleted;
                return true;
            }
            catch { return false; }
        }

        public bool DeleteCustomer(int customerID)
        {
            try
            {
                Customers customer = GetCustomerById(customerID);
                DeleteCustomer(customer);
                return true;
            }
            catch { return false; }
        }

        public IEnumerable<Customers> GetCustomerByFilter(string parameter)
        {
            return db.Customers.Where(c=>c.FullName.Contains(parameter) ||c.Email.Contains(parameter)||c.Mobile.Contains(parameter)).ToList();
        }
    }
}

