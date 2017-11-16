using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.ObjectModel;

namespace Budget.EntityFramework.Configuration
{
    class UserPasswordConfiguration
    {
        public static void Configure(EntityTypeConfiguration<UserPassword> configuration)
        {
            configuration.HasKey(e => e.UserLogin);
            configuration.Property(e => e.UserLogin).HasMaxLength(64).IsRequired();
            configuration.Property(e => e.Hash).HasMaxLength(32).IsFixedLength().IsRequired();
            configuration
                .HasRequired(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(true);

            string annotation = IndexAnnotation.AnnotationName;
            string indexName = "IX_UserIdUnique";

            configuration
                .Property(e => e.UserId)
                .HasColumnAnnotation(annotation, new IndexAnnotation(new IndexAttribute(indexName, 1) { IsUnique = true }));
        }
    }
}
