using BusinessLayer.Interface;
using CommonLayer.OrdersModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System;
using System.Linq;

namespace BookstoreWebAPI.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class OrderController : Controller
    {
        IOrderBL orderBL;
        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }
        [HttpPost("AddOrder")]
        public IActionResult AddOrder(OrderPostModel orderPostModel)
        {
            try
            {
                int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = this.orderBL.AddOrder(UserID, orderPostModel);

                if (result != null)
                {
                    return this.Ok(new { success = true, Message = "Order Placed Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = "Order Not Placed  " });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetAllOrder")]
        public IActionResult GetAllOrder()
        {
            try
            {
                int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = this.orderBL.GetAllOrder(UserID);

                if (result != null)
                {
                    return this.Ok(new { success = true, Message = "Order Get Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = "Order Not Found  " });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
