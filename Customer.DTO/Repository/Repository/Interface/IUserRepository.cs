using Customer.DTO.Models;
using Customer.DTO.Models.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.DTO.Repository.Repository.Interface
{
    public interface IUserRepository
    {
        List<User> GetCustomers(Roles rol);
        List<User> GetCustomerInfoById(string id);
        int CreateNewCustomer(User user);
        int UpdateCustomer(User userToUpdate);
        int RemoveCustomer(string id, Roles role);
        int SetAdmin(string id);
    }
}
