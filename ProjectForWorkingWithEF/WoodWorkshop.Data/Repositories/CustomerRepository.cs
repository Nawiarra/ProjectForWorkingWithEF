using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Data.Models;

namespace WoodWorkshop.Data.Repositories
{
    public class CustomerRepository
    {
        private readonly WoodWorkshopContext _ctx;
        public CustomerRepository() 
        {
            _ctx = new WoodWorkshopContext();
        }

        public Customer GetById(int customerId)
        {

            return _ctx.Customers
                .FirstOrDefault(x => x.Id == customerId);
                
        }
    }
}
