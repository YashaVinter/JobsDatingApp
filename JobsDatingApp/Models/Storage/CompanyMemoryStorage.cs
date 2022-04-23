using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace JobsDatingApp.Models.Storage
{
    public class CompanyMemoryStorage : IStorage<Company>
    {
        ISet<Company> companies = new HashSet<Company>
        {
            new(){ Id=1,Name="Sber",ShortDesc="Sber company",FullDesc="State company Sber", PhotoPath="/Files/CompanyPhoto/Sber.jpg"},
            new(){ Id=2,Name="VTB",ShortDesc="VTB company",FullDesc="Private company VTB"}
        };
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
