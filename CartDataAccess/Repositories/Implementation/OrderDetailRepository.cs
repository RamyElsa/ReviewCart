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
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private ApplicationDbContext _context;

        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);
            //var categoryDB = _context.Categories.FirstOrDefault(x => x.Id == orderHeader.Id);
            //if(categoryDB != null)
            //{
            //    categoryDB.Name = orderHeader.Name;
            //    categoryDB.DisplayOrder = categoryDB.DisplayOrder;
            //}
        }
    }
}
