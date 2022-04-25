using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JobsDatingApp.Models;

namespace Persistence
{
    internal interface IDataBase<T> where T : Ige
    {
        T<Company> Companies { get; set; }
        T<Vacancy> Vacancies { get; set; }
        T<User> Users { get; set; }

    }
}
