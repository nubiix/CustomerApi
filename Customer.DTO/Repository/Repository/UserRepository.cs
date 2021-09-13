using Customer.DTO.Models;
using Customer.DTO.Models.Constants;
using Customer.DTO.Models.EFModels;
using Customer.DTO.Repository.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Customer.DTO.Repository.Repository
{
    public class UserRepository: IUserRepository
    {
        private UserContext _db { get; set; }
        public UserRepository(UserContext db)
        {
            _db = db;
        }
        public List<User> GetCustomers(Roles rol)
        {
            return _db.User.Where(user => user.Role == rol)?.Select(data => new User(){ Name= data.Name, Id= data.Id })?.ToList();
        }

        public List<User> GetCustomerInfoById(string id)
        {
            return _db.User.Where(user => user.Id == id).ToList();
        }

        public User CreateNewCustomer(User user)
        {
            _db.Add(user);
            if (_db.SaveChanges() == 0)
            {
                return null;
            }
            return user;
        }
        public User UpdateCustomer(User userToUpdate)
        {
            var user = _db.User.Where(user => user.Id == userToUpdate.Id).FirstOrDefault();
            if (user != null)
            {
                user.Name = userToUpdate.Name;
                user.PhotoBase64 = userToUpdate.PhotoBase64;
                user.Role = userToUpdate.Role;
                user.Surname = userToUpdate.Surname;
                user.UserLastModified = userToUpdate.UserLastModified;
            }
            if (_db.SaveChanges() == 0)
            {
                return null;
            }
            return user;
        }
        public User RemoveCustomer(string id, Roles role)
        {
            var user = _db.User.Where(user => user.Id == id && user.Role == role).FirstOrDefault();
            _db.Remove(user);
            if (_db.SaveChanges() == 0)
            {
                return null;
            }
            return user;
        }
        public User SetAdmin(string id)
        {
            var user = _db.User.Where(user => user.Id == id).FirstOrDefault();
            if (user != null)
            {
                user.Role = Roles.Admin;
            }
            if (_db.SaveChanges() == 0)
            {
                return null;
            }
            return user;            
        }
    }
}
