using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Infra.Models;

namespace Todo.Infra.Mappings
{
    public class TodoItemMap : EntityTypeConfiguration<TodoItem>
    {
        public TodoItemMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(80);
            Property(x => x.IsComplete);
        }
    }
}
