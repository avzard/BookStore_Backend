using CommonLayer.OrdersModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IOrderBL
    {
        public string AddOrder(int UserId, OrderPostModel orderPostModel);
        public List<ViewOrder> GetAllOrder(int userId);
    }
}
