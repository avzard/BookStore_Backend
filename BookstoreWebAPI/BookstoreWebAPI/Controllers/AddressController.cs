using BusinessLayer.Interface;
using CommonLayer.AddressModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using System;
using System.Linq;
using BusinessLayer.Service;
using BusinessLayer.Services;

namespace BookstoreWebAPI.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class AddressController : Controller
    {
        IAddressBL AddressBL;

        public AddressController(IAddressBL addressBL)
        {
            AddressBL = addressBL;
        }
        [Authorize]
        [HttpPost("AddAddress")]
        public ActionResult AddAddress(AddressPostModel addressPostModel)
        {
            try
            {
                int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = AddressBL.AddAddress(UserID, addressPostModel);
                if (result != null)
                {
                    return this.Ok(new { success = true, Message = "Address Added Successfully", });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = "Address Not Added  " });

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpDelete("DeleteAddress")]
        public IActionResult DeleteAddress(int AddressId)
        {
            try
            {
                int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                

                var result = this.AddressBL.DeleteAddress(UserID, AddressId);

                if (result != null)
                {
                    return this.Ok(new { success = true, Message = "Address Deleted Successfully", });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = "Address Not Deleted  " });

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpGet("GetAddress")]
        public IActionResult GetAddress(int AddressId)
        {
            try
            {

                int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = this.AddressBL.GetAddress(UserID, AddressId);

                if (result != null)
                {
                    return this.Ok(new { success = true, Message = "Address Get Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = "Address Not Found  " });

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpPut("UpdateAddress")]
        public IActionResult UpdateAddress(AddressPostModel addressModel)
        {
            try
            {
                int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = this.AddressBL.UpdateAddress(UserID, addressModel);

                if (result != null)
                {
                    return this.Ok(new { success = true, Message = "Address Updated Successfully", });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = "Address Not Updated  " });

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
