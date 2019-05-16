using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Infra.Models;

namespace Todo.Infra.Mappings
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).HasMaxLength(80).IsRequired();
            HasMany(x => x.Items);
        }
    }
}
