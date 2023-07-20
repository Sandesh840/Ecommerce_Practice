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
        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IShopingCartRepository ShopingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IProductImageRepository ProductImage { get; private set; }
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            Category = new CategoryRepository(_applicationDbContext);
            Product = new ProductRepository(_applicationDbContext);
            Company = new CompanyRepository(_applicationDbContext);
            ShopingCart = new ShopingCartRepository(_applicationDbContext);
            ApplicationUser = new ApplicationUserRepository(_applicationDbContext);
            OrderDetail = new OrderDetailRepository(_applicationDbContext);
            OrderHeader = new OrderHeaderRepository(_applicationDbContext);
            ProductImage = new ProductImageRepository(_applicationDbContext);
        }
        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}