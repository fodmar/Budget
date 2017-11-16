using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.EntityFramework.Configuration
{
    class ProductConfiguration
    {
        public static void Configure(EntityTypeConfiguration<Product> configuration)
        {
            configuration.Property(e => e.Name).IsRequired().HasMaxLength(64);
        }
    }
}
