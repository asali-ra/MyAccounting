using Accounting.DataLayer.Repository;
using Accounting.DataLayer.Service;
using System;

namespace Accounting.DataLayer.Context
{
    public class UnitOfWork:IDisposable
    {
        Accounting_DBEntities db= new Accounting_DBEntities();

        private ICustomerRepository _customerRepository;

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(db);
                }
                return _customerRepository;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
