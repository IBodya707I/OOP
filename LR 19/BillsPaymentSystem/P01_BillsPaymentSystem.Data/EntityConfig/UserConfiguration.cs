using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P01_BillsPaymentSystem.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    internal class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(50).IsUnicode(true);
            builder.Property(u => u.LastName).HasMaxLength(50).IsUnicode(true);
            builder.Property(u => u.Email).HasMaxLength(80).IsUnicode(false);
            builder.Property(u => u.Password).HasMaxLength(25).IsUnicode(false);
        }
    }
}
