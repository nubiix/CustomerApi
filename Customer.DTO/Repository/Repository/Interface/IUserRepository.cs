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
        User CreateNewCustomer(User user);
        User UpdateCustomer(User userToUpdate);
        User RemoveCustomer(string id, Roles role);
        User SetAdmin(string id);
    }
}
