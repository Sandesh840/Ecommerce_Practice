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
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public OrderHeaderRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }



        public void Update(OrderHeader obj)
        {
            _applicationDbContext.OrderHeader.Update(obj);
        }

		public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
		{
			var orderFromDb=_applicationDbContext.OrderHeader.FirstOrDefault(u=>u.Id == id);
              if (orderFromDb!= null)
            {
                orderFromDb.OrderStatus = orderStatus;
                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    orderFromDb.PaymentStatus= paymentStatus;
                }
            }
		}

		public void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId)
		{
			var orderFromDb = _applicationDbContext.OrderHeader.FirstOrDefault(u => u.Id == id);							
				if (!string.IsNullOrEmpty(sessionId))
				{
					orderFromDb.SessionId = sessionId;
				}
			if (!string.IsNullOrEmpty(paymentIntentId))
			{
				orderFromDb.PaymentIntentId = paymentIntentId;
				orderFromDb.PaymentDate = DateTime.Now  ;
			}

		}
	}
}