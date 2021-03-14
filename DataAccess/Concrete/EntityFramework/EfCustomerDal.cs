using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RecapContext>, ICustomerDal
    {
        public List<CustomerListDto> CustomerListDtos()
        {
            using (RecapContext recapContext=new RecapContext())
            {
                var results = from customer in recapContext.Customers
                    join user in recapContext.Users on customer.UserId equals user.Id select new CustomerListDto
                    {
                        Id = customer.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        CompanyName = customer.CompanyName
                    };
                return results.ToList();
            }
        }
    }
}