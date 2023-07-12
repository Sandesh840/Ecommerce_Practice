using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository
{
    public class ShopingCartRepository : Repository<ShoppingCart>, IShopingCartRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ShopingCartRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }



        public void Update(ShoppingCart obj)
        {
            _applicationDbContext.Update(obj);
        }
    }
}