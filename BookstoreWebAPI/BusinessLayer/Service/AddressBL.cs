using BusinessLayer.Interface;
using CommonLayer.AddressModel;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AddressBL: IAddressBL
    {
        IAddressRL addressRL;
        public AddressBL(IAddressRL addressRL)
        {
            this.addressRL = addressRL;
        }
        public string AddAddress(int UserId, AddressPostModel addressPostModel)
        {
            try
            {
                return this.addressRL.AddAddress(UserId, addressPostModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteAddress(int UserId, int AddressId)
        {
            try
            {
                return this.addressRL.DeleteAddress(UserId, AddressId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public AddressPostModel GetAddress(int UserId, int AddressId)
        {
            try
            {
                return this.addressRL.GetAddress(UserId, AddressId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string UpdateAddress(int UserId, AddressPostModel addressPostModel)
        {
            try
            {
                return this.addressRL.UpdateAddress(UserId, addressPostModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
