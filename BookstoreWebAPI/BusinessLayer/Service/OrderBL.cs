using BusinessLayer.Interface;
using CommonLayer.OrdersModel;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class OrderBL : IOrderBL
    {

        IOrderRL orderRL;
        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }
        public string AddOrder(int UserId, OrderPostModel orderPostModel)
        {
			try
			{
                return this.orderRL.AddOrder(UserId, orderPostModel);
            }
			catch (Exception)
			{

				throw;
			}
        }
        public List<ViewOrder> GetAllOrder(int userId)
        {
            try
            {
                return this.orderRL.GetAllOrder(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
