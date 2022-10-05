using CommonLayer.OrdersModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IOrderRL
    {
        public string AddOrder(int UserId, OrderPostModel orderPostModel);
        public List<ViewOrder> GetAllOrder(int userId);
    }
}
