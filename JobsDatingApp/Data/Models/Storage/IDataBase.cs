using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JobsDatingApp.Models;

namespace JobsDatingApp.Models
{
    /// <summary>
    /// TODO IDataBase<T>
    /// T<Company> Companies
    /// </summary>
    internal interface IDataBase
    {
        IEnumerable<Company> Companies { get; set; }
        IEnumerable<Vacancy> Vacancies { get; set; }
        IEnumerable<User> Users { get; set; }

    }
}
