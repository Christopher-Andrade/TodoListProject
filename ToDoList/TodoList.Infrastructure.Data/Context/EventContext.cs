using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;
using TodoList.Domain.Entities.Comment;

namespace TodoList.Infrastructure.Data
{
    public class EventContext : DbContext
    {
      


        public EventContext()
        {
            
        }
        public EventContext(DbContextOptions options) : base(options)
        {
            
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<Province> Provinces { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
    }
}
