using CartDataAccess.Repositories.Abstract;
using CartModels;
using ReviewCart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartDataAccess.Repositories.Implementation
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private ApplicationDbContext _context;
        public OrderHeaderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void PaymentStatus(int Id, string SessionId, string PaymentIntentId)
        {
          var orderHeader = _context.OrderHeaders.FirstOrDefault(x => x.Id == Id);
            orderHeader.DateOfPayment = DateTime.Now;
            orderHeader.PaymentIntentId = PaymentIntentId;
            orderHeader.SessionId = SessionId;
        }

        public void Update(OrderHeader orderHeader)
        {
           _context.OrderHeaders.Update(orderHeader);

            //var categoryDB = _context.Categories.FirstOrDefault(x => x.Id == orderHeader.Id);
            //if(categoryDB != null)
            //{
            //    categoryDB.Name = orderHeader.Name;
            //    categoryDB.DisplayOrder = categoryDB.DisplayOrder;
            //}
        }

        public void UpdateStatus(int Id, string orderStatus, string? paymentStatus = null)
        {
            var order = _context.OrderHeaders.FirstOrDefault(x => x.Id == Id);
            if(order != null)
            {
                order.OrderStatus= orderStatus;
            }
            if(paymentStatus != null)
            {
                order.PaymentStatuse = paymentStatus;
            }

        }
    }
}
