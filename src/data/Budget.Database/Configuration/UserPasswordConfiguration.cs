using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.Database.Configuration
{
    class UserPasswordConfiguration
    {
        public static void Configure(EntityTypeConfiguration<UserPassword> configuration)
        {
            configuration.HasKey(e => e.UserId);
            configuration.Property(e => e.UserLogin).HasMaxLength(64).IsRequired();
            configuration.Property(e => e.Hash).HasMaxLength(32).IsFixedLength().IsRequired();
        }
    }
}
