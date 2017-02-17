using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;
using TodoList.Domain.Entities.Comment;

namespace TodoList.Infrastructure.Data.Context
{
    public class ProjectContext : DbContext
    {
        //private readonly string connString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-ToDoList-10a4ccee-7ca1-45ad-ac30-34e4f7261c7b;Trusted_Connection=True;MultipleActiveResultSets=true";

        private ProjectContext()
        {

        }

        public ProjectContext(DbContextOptions options) : base(options)
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
