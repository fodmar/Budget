using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.Database.Configuration
{
    class UserConfiguration
    {
        public static void Configure(EntityTypeConfiguration<User> configuration)
        {
            configuration.Property(e => e.Name).HasMaxLength(128).IsRequired();
            configuration.Property(e => e.Email).HasMaxLength(128).IsRequired();
        }
    }
}
