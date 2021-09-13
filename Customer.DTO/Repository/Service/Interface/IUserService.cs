using Customer.DTO.Models;
using Customer.DTO.Models.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.DTO.Repository.Service.Interface
{
    public interface IUserService
    {
        List<User> GetUsers(Roles rol);
        List<User> GetCustomerInfoById(string id);
        User CreateNewCustomer(User user);
        User UpdateCustomer(User userToUpdate);
        User RemoveCustomer(string id, Roles role);
        User SetAdmin(string id);
    }
}
