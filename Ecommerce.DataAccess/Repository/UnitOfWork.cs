using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(ApplicationDbContext applicationDbContext)  
        {
            _applicationDbContext = applicationDbContext;
            Category=new CategoryRepository(_applicationDbContext);
        }
       

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
