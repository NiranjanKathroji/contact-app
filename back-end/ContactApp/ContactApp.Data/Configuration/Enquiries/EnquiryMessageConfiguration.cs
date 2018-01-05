using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContactApp.Core.Domain.Enquiries;

namespace ContactApp.Data.Configuration.Enquiries
{
    public class EnquiryConfiguration : IEntityTypeConfiguration<Enquiry>
    {
        /// <summary>
        /// Configure the enquiry message entity.
        /// </summary>
        /// <returns>The configure.</returns>
        /// <param name="builder">Builder.</param>
        public void Configure(EntityTypeBuilder<Enquiry> builder)
        {
            builder.ToTable("EnquiryMessage");
            builder.HasKey(em => em.Id);
            builder.Property(em => em.Title).IsRequired().HasMaxLength(200);
            builder.Property(em => em.Message).IsRequired().HasMaxLength(1000);


            builder.HasOne(p => p.Customer)
                   .WithMany(b => b.Enquiries)
                   .HasForeignKey(p => p.CustomerId)
                   .HasConstraintName("FK_Enquiry_Customer");
            //.OnDelete(DeleteBehavior.Cascade);

        }
    }
}
