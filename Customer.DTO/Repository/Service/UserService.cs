using Customer.DTO.Models;
using Customer.DTO.Models.Constants;
using Customer.DTO.Repository.Repository.Interface;
using Customer.DTO.Repository.Service.Interface;
using System.Collections.Generic;

namespace Customer.DTO.Repository.Service
{
    public class UserService: IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetUsers(Roles rol) 
        {
            return _userRepository.GetCustomers(rol);
        }

        public List<User> GetCustomerInfoById(string id)
        {
            return _userRepository.GetCustomerInfoById(id); 
        }
        public User CreateNewCustomer(User user) 
        {
            return _userRepository.CreateNewCustomer(user);
        }
        
        public User UpdateCustomer(User userToUpdate)
        {
            return _userRepository.UpdateCustomer(userToUpdate);
        }
        public User RemoveCustomer(string id, Roles role)
        {
            return _userRepository.RemoveCustomer(id,role);
        }

        public User SetAdmin(string id)
        {
            return _userRepository.SetAdmin(id);
        }
    }
}
