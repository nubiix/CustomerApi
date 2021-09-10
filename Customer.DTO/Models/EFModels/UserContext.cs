using Microsoft.EntityFrameworkCore;
using System;
namespace Customer.DTO.Models.EFModels
{
    public class UserContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public string DbPath { get; private set; }

        public UserContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}users.db";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
