using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.Database.Configuration
{
    class ReceiptConfiguration
    {
        public static void Configure(EntityTypeConfiguration<Receipt> configuration)
        {
            string annotation = IndexAnnotation.AnnotationName;
            string indexName = "IX_UserIdDate";

            configuration
                .Property(e => e.UserId)
                .HasColumnAnnotation(annotation, new IndexAnnotation(new IndexAttribute(indexName, 1)));

            configuration
                .Property(e => e.Date)
                .HasColumnAnnotation(annotation, new IndexAnnotation(new IndexAttribute(indexName, 2)));
        }
    }
}