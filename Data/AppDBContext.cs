using Demo_Web_API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Demo_Web_API.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        
    }
}
