using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Data.Models;

namespace DevShop.Data.Repository
{
    public interface IRepository
    {
        Country GetCountryByShortName(string shortName);
    }
}
