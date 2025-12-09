using BillsPaymentSystem.P01_BillsPaymentSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    internal class BankAccountConfiguration: IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.Property(s => s.BankName).HasMaxLength(50).IsUnicode(true);
            builder.Property(s => s.SwiftCode).HasMaxLength(20).IsUnicode(false);
            builder.Property(s => s.Balance).HasPrecision(18, 2);
        }
    }
}
