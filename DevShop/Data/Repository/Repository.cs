using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevShop.Data.Models;

namespace DevShop.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly DevShopDbContext _dbContext;

        public Repository(DevShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Country GetCountryByShortName(string shortName)
        {
            return _dbContext.Countries.FirstOrDefault(c => c.ShortName == shortName);
        }
    }
}
