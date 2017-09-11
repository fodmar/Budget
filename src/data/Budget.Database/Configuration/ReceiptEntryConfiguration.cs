using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.Database.Configuration
{
    class ReceiptEntryConfiguration
    {
        public static void Configure(EntityTypeConfiguration<ReceiptEntry> configuration)
        {
            configuration
                .HasRequired(e => e.Product)
                .WithMany()
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);
        }
    }
}