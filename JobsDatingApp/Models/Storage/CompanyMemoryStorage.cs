using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace JobsDatingApp.Models.Storage
{
    public class CompanyMemoryStorage : IStorage<Company>
    {
        ISet<Company> companies;
        public Company? Get(int Id)
        {
            return companies.FirstOrDefault(c => c.Id == Id);
        }

        public Company? Post(Company t)
        {
            return companies.Add(t) ? t : null;
        }

        public Company? Put(Company t)
        {
            throw new NotImplementedException();
        }
        public Company? Delete(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
