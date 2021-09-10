using Customer.DTO.Models;
using Customer.DTO.Models.Constants;
using Customer.DTO.Models.EFModels;
using Customer.DTO.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public int CreateNewCustomer(User user)
        {
            _db.Add(user);
            return _db.SaveChanges();
        }
        public int UpdateCustomer(User userToUpdate)
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
            return _db.SaveChanges();
        }
        public int RemoveCustomer(string id, Roles role)
        {
            var user = _db.User.Where(user => user.Id == id && user.Role == role).FirstOrDefault();
            _db.Remove(user);
            return _db.SaveChanges();
        }
        public int SetAdmin(string id)
        {
            var user = _db.User.Where(user => user.Id == id).FirstOrDefault();
            if (user != null)
            {
                user.Role = Roles.Admin;
            }
            return _db.SaveChanges();
        }
    }
}
