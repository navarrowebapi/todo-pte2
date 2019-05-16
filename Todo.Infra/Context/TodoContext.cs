using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Infra.Mappings;
using Todo.Infra.Models;

namespace Todo.Infra.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Api5SemDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new TodoItemMap());
        }
    }
}
