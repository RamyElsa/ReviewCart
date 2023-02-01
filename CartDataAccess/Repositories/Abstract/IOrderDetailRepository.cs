using CartModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartDataAccess.Repositories.Abstract
{
    public interface IOrderDetailRepository
    {
        void Update(OrderDetail orderDetail);
    }
}
