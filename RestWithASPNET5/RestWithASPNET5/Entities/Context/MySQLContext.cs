﻿using Microsoft.EntityFrameworkCore;
using RestWithASPNET5.Entities;

namespace RestWithASPNET5.Models.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
